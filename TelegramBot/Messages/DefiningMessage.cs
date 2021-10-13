using Telegram.Bot.Args;
using TelegramBot.Messages.Handlers;

namespace TelegramBot.Messages
{
    /// <summary>
    /// Определение сообщений ботом.
    /// </summary>
    public class DefiningMessage
    {
        /// <summary>
        /// Определение типа сообщения.
        /// </summary>
        public object TypeForMessage(MessageEventArgs args)
        {
            if (args.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text) return null;

            var say = new MessageSayHandler();
            var anek = new MessageAnekHandler();
            var help = new MessageHelpHandler();

            say.SetNext(anek).SetNext(help);
            return say.Handle(args);
        }
    }
}
