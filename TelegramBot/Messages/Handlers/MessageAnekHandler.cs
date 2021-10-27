using Telegram.Bot.Args;
using TelegramBot.Messages.TextMessages;

namespace TelegramBot.Messages.Handlers
{
    /// <summary>
    /// Обработчик для обработки команды /anek (рандомный анекдот)
    /// </summary>
    internal class MessageAnekHandler : AbstractHandler
    {
        /// <summary>
        /// Обработать запрос (если есть обработчик)
        /// </summary>
        public override object Handle(MessageEventArgs args)
        {
            return args.Message.Text.IndexOf("/anek") != -1 ? new SendingTextMessage().SendingMessage(args) : base.Handle(args);
        }
    }
}
