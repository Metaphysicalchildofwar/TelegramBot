using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Messages.TextMessages
{
    /// <summary>
    /// Отправка списка команд
    /// </summary>
    public class SendingHelpMessage : SendMessage
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
            //parseMode: ParseMode.Markdown, 
            //replyMarkup: Buttons.GetButtons());
        }

        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public override string SendingMessage(MessageEventArgs args)
        {
            Message mes = MessageFromBot("/say - озвучить текст\n/anek - рандомный анекдот", args).Result;
            return LoggingMessages.LogMess(mes, true);
        }
    }
}
