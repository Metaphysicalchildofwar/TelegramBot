using ParseAneks;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBot.Messages.TextMessages
{
    /// <summary>
    /// Отправка текстовых сообщений
    /// </summary>
    public class SendingTextMessage : SendMessage
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
            Message mes = MessageFromBot(ParsingAneks.ParsAnek() ?? "Анека не будет", args).Result;
            return LoggingMessages.LogMess(mes, true);
        }
    }
}

