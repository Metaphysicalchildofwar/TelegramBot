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
            if (args.Message.Text.IndexOf("/say") != -1)
            {
                SendMessage sendMessage = new SendingVoiceMessage() { };
                return sendMessage.SendingMessage(args);
            }
            else
            {
                return base.Handle(args);
            }
        }
    }
}
