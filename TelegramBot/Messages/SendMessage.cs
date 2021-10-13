using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBot.Messages
{
    /// <summary>
    /// Родительский класс отправки сообщений
    /// </summary>
    public abstract class SendMessage
    {
        /// <summary>
        /// Формирует текстовое сообщение.
        /// </summary>
        public abstract Task<Message> MessageFromBot(string from, MessageEventArgs args);

        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public abstract string SendingMessage(MessageEventArgs args);
    }
}
