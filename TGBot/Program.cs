using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TGBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Host mamonBot = new Host("7509758606:AAEeefHNvn8STsXxGykjdNf63ghrEQYT0Gk");
            mamonBot.BotStart();
            mamonBot.OnMessage += OnMessage;
            Console.ReadLine();
        }

        private static async void OnMessage(ITelegramBotClient client, Update update)
        {
            if (update.Message?.Text == "/start")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 1992185162, "Darova!", replyToMessageId: update.Message?.MessageId);

            }
            else if (update.Message?.Text == "/about")
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 1992185162, "Це початкова структура для бота, тут ще нічого толкового не реалізовано.", replyToMessageId: update.Message?.MessageId);
            }
            else
            {
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 1992185162, update.Message?.Text ?? "Ne text", replyToMessageId: update.Message?.MessageId);

            }
        }
    }
}
