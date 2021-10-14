using Telegram.Bot.Types;

namespace TelegramBot.Messages
{
    /// <summary>
    /// Логирование сообщений.
    /// </summary>
    public class LoggingMessages
    {
        /// <summary>
        /// Логирование отправленных/принятых сообщений.
        /// Метод записывает в файл и возвращает текст сообщений.
        /// Если from == true - логирование исходящего сообщения, иначе - логирование входящего сообщения.
        /// </summary>
        public static string LogMess (Message args, bool from)
        {
            var Name = from == true ? args.From.FirstName : args.Chat.FirstName;
            var mes = $"{args.Date.ToLocalTime()} от {Name} сообщение типа {args.Type}: {args.Text}";
            return mes;
        }
    }
}
