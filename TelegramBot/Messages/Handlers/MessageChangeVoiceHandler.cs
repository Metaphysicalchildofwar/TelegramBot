using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramBot.Messages.TextMessages;

namespace TelegramBot.Messages.Handlers
{
    /// <summary>
    /// Изменяет голос.
    /// </summary>
    internal class MessageChangeVoiceHandler : AbstractHandler
    {
        /// <summary>
        /// Обработать запрос (если есть обработчик)
        /// </summary>
        public override object Handle(MessageEventArgs args)
        {
            if (args.Message.Text.IndexOf("/change") != -1)
            {
                SendMessage sendMessage = new SendingChangeVoiceMessage() { };
                return sendMessage.SendingMessage(args);
            }
            else
            {
                return base.Handle(args);
            }
        }
    }
}
