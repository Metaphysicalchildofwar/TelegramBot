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
            if (args.Message.Text.IndexOf("/help") != -1 || args.Message.Text.IndexOf("/start") != -1)
            {
                SendMessage _sendMessage = new SendingHelpMessage() { };
                return _sendMessage.SendingMessage(args);
            }
            else
            {
                return base.Handle(args);
            }
        }
    }
}
