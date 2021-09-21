using ParseAneks;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Sending
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
                replyToMessageId: args.Message.MessageId, 
                //parseMode: ParseMode.Markdown, 
                replyMarkup: Buttons.GetButtons());
        }

        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public override string SendingMessage(MessageEventArgs args)
        {
            Message mes = MessageFromBot(ParsingAneks.ParsAnek(), args).Result;
            return LoggingMessages.LogMess(mes, true);
        }
    }
}

