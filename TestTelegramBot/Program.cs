using System;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using TelegramBot;

namespace TestTelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {

            InitializeBot.Client.StartReceiving();

            InitializeBot.Client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            InitializeBot.Client.StopReceiving();
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            try
            {
                //логирование приема сообщений
                Console.WriteLine(Task.Run(() => LoggingMessages.LogMess(e.Message, false)).Result);
                //отправка сообщений
                Console.WriteLine(Task.Run(() => SendingMessages.SendMessage(e)).Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
