using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace CortanaSuiteBot.Dialogs
{
    [Serializable]
    public class BotWelcomeDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            return context.PostAsync("hi there");

           
        }

        private async Task MessageReceivedAsync(IDialogContext context)
        {
           // var activity = await result as IMessageActivity;

            await context.PostAsync("hi there");
            // TODO: Put logic for handling user message here

            // context.Wait(MessageReceivedAsync);
        }
    }
}