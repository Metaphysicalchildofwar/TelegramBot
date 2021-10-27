using Telegram.Bot.Args;
using TelegramBot.Messages.VoiceMessages;

namespace TelegramBot.Messages.Handlers
{
    /// <summary>
    /// Обработчик для обработки команды /say (озвучить текст)
    /// </summary>
    internal class MessageSayHandler : AbstractHandler
    {
        /// <summary>
        /// Обработать запрос (если есть обработчик)
        /// </summary>
        public override object Handle(MessageEventArgs args)
        {
            return args.Message.Text.IndexOf("/say") != -1 ? new SendingVoiceMessage().SendingMessage(args) : base.Handle(args);
        }
    }
}
