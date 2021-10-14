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
            if (args.Chat.Type == Telegram.Bot.Types.Enums.ChatType.Supergroup)
            {
                return $"{args.Date.ToLocalTime()} из группы '{args.Chat.Title}' сообщение типа {args.Type}: {args.Text}";
            }
            else
            {
                var Name = from == true ? args.From.FirstName : args.Chat.FirstName;
                return $"{args.Date.ToLocalTime()} от '{Name}' сообщение типа {args.Type}: {args.Text}";
            }
        }
    }
}
