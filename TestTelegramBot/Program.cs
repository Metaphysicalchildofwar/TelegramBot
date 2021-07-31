using ParseVkMemes;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using TelegramBot;
using VkNet;

namespace TestTelegramBot
{
    class Program
    {
        static DefiningMessage messages = new DefiningMessage();
        static VkApi AuthUser = Authorization.LogIn();
        static void Main(string[] args)
        {
            try
            {
                //Вк
                // 527043048 
                ParseVkMemes.Authorization.Err += (x) => Console.WriteLine(x);

                //Телеграм
                InitializeBot.Client.SetWebhookAsync("");
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
                Console.WriteLine(Task.Run(() => messages.TypeForMessage(e, AuthUser)).Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
