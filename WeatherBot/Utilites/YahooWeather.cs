using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using RestSharp;

namespace WeatherBot.Utilites
{
    public class YahooWeather
    {
        public async Task GetWeatherFromYahoo(IDialogContext context, string location)
        {
            try
            {
                var client = new RestClient($"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22"+location+"%22)&format=json");
                var request = new RestRequest(Method.GET);
                request.AddHeader("accept", "application/json");
                IRestResponse response = client.Execute(request);
                var result = JsonConvert.DeserializeObject<WeatherReportDS>(response.Content);

                var reply = context.MakeMessage();
                var  report = result.query.results.channel;
                var heroCard = new ThumbnailCard
                {
                    Title = report.title.Split('-')[1].Trim(),
                    Subtitle = report.item.condition.date,
                    Text = "<b>Temperature :</b><BR />" + report.item.condition.temp +" " + report.units.temperature + "<BR /><b>Current Condition :</b><BR />" + report.item.condition.text + "<BR />",
                    Images = new List<CardImage> { new CardImage("http://l.yimg.com/a/i/us/we/52/" + report.item.condition.code + ".gif") },
                    Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Full Forecast", value: "https://weather.yahoo.com/" + report.location.country + '/' + report.location.region.Trim() + '/' + report.location.city + '-' + getWOEID(report.location.city)+'/') }
                }.ToAttachment();

                reply.Attachments.Add(heroCard);

                await context.PostAsync(reply);
                context.Done(true);

            }
            catch(Exception e)
            {
                await context.PostAsync($"sorry I didn't get the Location.");
            }
        }

        private string getWOEID(string city)
        { 
                var client = new RestClient($"https://query.yahooapis.com/v1/public/yql?q=select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + city + "%22&format=json");
                var request = new RestRequest(Method.GET);
                request.AddHeader("accept", "application/json");
                IRestResponse response = client.Execute(request);
                var result = JsonConvert.DeserializeObject<WeatherReportDS>(response.Content);
                return result.query.results.place.woeid;
        }
    }
}