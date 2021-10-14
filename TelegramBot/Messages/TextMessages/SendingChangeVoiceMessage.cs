using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBot.Messages.TextMessages
{
    /// <summary>
    /// Формирует текстовое сообщение.
    /// </summary>
    public class SendingChangeVoiceMessage : SendMessage
    {
        /// <summary>
        /// Формирует текстовое сообщение.
        /// </summary>
        public override async Task<Message> MessageFromBot(string from, MessageEventArgs args)
        {
            return await InitializeBot.Client.SendTextMessageAsync(
                args.Message.Chat.Id,
                from,
                replyToMessageId: args.Message.MessageId);
        }

        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public override string SendingMessage(MessageEventArgs args)
        {

            Message mes = MessageFromBot("голос бота изменен", args).Result;
            return LoggingMessages.LogMess(mes, true);
        }
    }
}
