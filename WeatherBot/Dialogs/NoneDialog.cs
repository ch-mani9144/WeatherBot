using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;

namespace SimpleEchoBot.Dialogs
{
    [Serializable]
    public class NoneDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait<LuisResult>(this.NoneDialogProcessAsync);
            //return Task.CompletedTask;
        }

        public async Task NoneDialogProcessAsync(IDialogContext context, IAwaitable<LuisResult> luisResult)
        {
            await context.PostAsync("Sometimes, I may not have the information you need.");
            await context.PostAsync("Right Now I can only help with Weather Deatails of given location. :)");
            context.Done(true);
        }
    }
}