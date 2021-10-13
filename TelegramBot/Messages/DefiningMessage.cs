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
            var say = new MessageSayHandler();
            var anek = new MessageAnekHandler();
            var help = new MessageHelpHandler();

            if (args.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text) return null;
            say.SetNext(anek).SetNext(help);
            return say.Handle(args);
        }
    }
}
