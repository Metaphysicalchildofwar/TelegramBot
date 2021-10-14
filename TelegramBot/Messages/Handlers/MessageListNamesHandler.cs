using Telegram.Bot.Args;
using TelegramBot.Messages.TextMessages;

namespace TelegramBot.Messages.Handlers
{
    /// <summary>
    /// Обработчик для обработки команды /change (список голосов)
    /// </summary>
    internal class MessageListNamesHandler : AbstractHandler
    {
        /// <summary>
        /// Обработать запрос (если есть обработчик)
        /// </summary>
        public override object Handle(MessageEventArgs args)
        {
            if (args.Message.Text.IndexOf("/names") != -1)
            {
                SendMessage _sendMessage = new SendingListNamesMessage() { };
                return _sendMessage.SendingMessage(args);
            }
            else
            {
                return base.Handle(args);
            }
        }
    }
}
