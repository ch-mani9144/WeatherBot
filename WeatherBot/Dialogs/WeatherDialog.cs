using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using SimpleEchoBot.Dialogs;
using WeatherBot.Utilites;

namespace WeatherBot.Dialogs
{
    [Serializable]
    internal class WeatherDialog : IDialog<object>
    {
        public async  Task StartAsync(IDialogContext context)
        {
            context.Wait<LuisResult>(this.WeatherReport);
        }

        private async Task WeatherReport(IDialogContext context, IAwaitable<LuisResult> result)
        {
            var luisresult = await result;
            EntityRecommendation _location;
            var reply = context.MakeMessage();
            YahooWeather yw = new YahooWeather();

            if (luisresult.TryFindEntity("LocName", out _location))
            {
                await yw.GetWeatherFromYahoo(context, _location.Entity.ToString());
                context.Done(true);
            }
            else
            {
                await context.Forward(new NoneDialog(), this.WeatherAfterAsync, result, System.Threading.CancellationToken.None);
            }
        }

        public async Task WeatherAfterAsync(IDialogContext context, IAwaitable<object> result)
        {
            context.Done(true);
        }
    }
}