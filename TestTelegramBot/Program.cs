
using System;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using TelegramBot;
using TelegramBot.Messages;

namespace WorkTelegramBot
{
    class Program
    {
        static DefiningMessage messages = new DefiningMessage();
        static void Main(string[] args)
        {
            try
            {
                //Телеграм
                InitializeBot.Client.SetWebhookAsync("");
                Console.WriteLine($"Бот {InitializeBot.Client.GetMeAsync().Result.FirstName} включен.");
                InitializeBot.Client.StartReceiving();
                InitializeBot.Client.OnMessage += OnMessageHandler;
                Console.ReadLine();
                InitializeBot.Client.StopReceiving();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            try
            {
                
                //логирование приема сообщений
                Console.WriteLine(Task.Run(() => LoggingMessages.LogMess(e.Message, false)).Result);
                //отправка сообщений
                Console.WriteLine(Task.Run(() => messages.TypeForMessage(e)).Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
