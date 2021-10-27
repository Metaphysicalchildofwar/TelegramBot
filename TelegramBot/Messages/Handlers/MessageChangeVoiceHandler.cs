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
            return args.Message.Text.IndexOf("/change") != -1 ? new SendingChangeVoiceMessage().SendingMessage(args) : base.Handle(args);
        }
    }
}
