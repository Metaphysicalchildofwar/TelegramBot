using Telegram.Bot.Args;
using TelegramBot.Messages.TextMessages;

namespace TelegramBot.Messages.Handlers
{
    /// <summary>
    /// Обработчик для обработки команды /help (список команд)
    /// </summary>
    internal class MessageHelpHandler : AbstractHandler
    {
        /// <summary>
        /// Обработать запрос (если есть обработчик)
        /// </summary>
        public override object Handle(MessageEventArgs args)
        {
            return args.Message.Text.IndexOf("/help") != -1 || args.Message.Text.IndexOf("/start") != -1 ? new SendingHelpMessage().SendingMessage(args) : base.Handle(args);
        }
    }
}
