using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using CortanaSuiteBot.DataServices;

namespace CortanaSuiteBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {

            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            

            var activity = await result as Activity;

            // calculate something for us to return
            // int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            // await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            await context.PostAsync("Ten cuidado! La multa mas comun en estos momentos es:");

            var mlResponse = await MLService.InvokeRequestResponseService();
            await context.PostAsync(mlResponse);

            context.Wait(MessageReceivedAsync);
        }
    }
}