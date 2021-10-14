using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TextScoring.ChangeVoice;

namespace TelegramBot.Messages.TextMessages
{
    /// <summary>
    /// Отправка списка голосов
    /// </summary>
    public class SendingListNamesMessage : SendMessage
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
            Message mes = MessageFromBot(GenerateMessage(), args).Result;
            return LoggingMessages.LogMess(mes, true);
        }

        /// <summary>
        /// Сформировать сообщение списка голосов.
        /// </summary>
        private string GenerateMessage()
        {
            string _text = string.Empty;
            foreach (var n in GetAListOfVotes.GetNames())
            {
                _text += n + '\n';
            }
            return _text;
        }
    }
}
