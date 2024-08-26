using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TGBot
{
    public class Host
    {
        public Action<ITelegramBotClient, Update>? OnMessage;
        private TelegramBotClient _bot;

        public Host(string bottoken)
        {
            _bot = new TelegramBotClient(bottoken);
        }
        
        public void BotStart()
        {
            _bot.StartReceiving(UpdateHandler, ErrorHandler);
            Console.WriteLine("ON");
        }

        private async Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine("Error " +  exception.Message);
            await Task.CompletedTask;

        }

        private async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
        {
            Console.WriteLine($"Message: {update.Message?.Text ?? "ne text"}");
            OnMessage?.Invoke(client, update);
            await Task.CompletedTask;
        }   
    }
}
