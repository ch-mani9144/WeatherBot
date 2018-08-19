using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using SimpleEchoBot.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WeatherBot.Dialogs
{
    [Serializable]
    [LuisModel("8de54113-6416-4fa2-82d4-aa61abb9a44d", "016928ba5d6e4e92b3d5a7bd4fac3ebf", LuisApiVersion.V2, "westus.api.cognitive.microsoft.com")]

    public class BotLuisDialog : LuisDialog<object>
    {
        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Hello...!");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Weather.GetForecast")]
        public async Task getWeatherAsync(IDialogContext context, LuisResult result)
        {
            await context.Forward(new WeatherDialog(), OnCompeletionAsync, result, System.Threading.CancellationToken.None);
        }

        [LuisIntent("None")]
        public async Task NoneAsync(IDialogContext context, LuisResult result)
        {
            await context.Forward(new NoneDialog(), OnCompeletionAsync, result, System.Threading.CancellationToken.None);
        }

        private async Task OnCompeletionAsync(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
       
        }
    }
}