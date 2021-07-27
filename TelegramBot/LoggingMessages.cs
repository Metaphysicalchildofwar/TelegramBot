using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
    /// <summary>
    /// Логирование сообщений.
    /// </summary>
    public class LoggingMessages
    {
        private static string Path { get; } = @"E:\Study\TelegramBot\TelegramBot\logfile.txt";

        /// <summary>
        /// Логирование отправленных/принятых сообщений.
        /// Метод записывает в файл и возвращает текст сообщений.
        /// Если from == true - логирование исходящего сообщения, иначе - логирование входящего сообщения.
        /// </summary>
        public static string LogMess (Message args, bool from)
        {
            var Name = from == true ? args.From.FirstName : args.Chat.FirstName;
            var mes = $"{args.Date.ToLocalTime()} от {Name} сообщение типа {args.Type}: {args.Text}";
            WorkRecording(mes);
            return mes;
        }

        /// <summary>
        /// Логирование в файл.
        /// </summary>
        public static void WorkRecording(string mes)
        {
            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
            {
                sw.Write(String.Concat(mes,'\n'));
            }
        }
    }
}
