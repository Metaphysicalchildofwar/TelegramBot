using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

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
        }

        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public override string SendingMessage(MessageEventArgs args)
        {
            Message mes = MessageFromBot("Доступные команды:\n/anek - рандомный анекдот\n/say - озвучить текст\n/change - изменить голос озвучки текста\n/names - список доступных голосов для озвучки текста\n/help - список всех команд", args).Result;
            return LoggingMessages.LogMess(mes, true);
        }
    }
}
