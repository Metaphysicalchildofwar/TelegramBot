using System;
using System.Configuration;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TextScoring.CreateVoiceMessage;

namespace TelegramBot.Messages.VoiceMessages
{
    /// <summary>
    /// Отправляет голосовое сообщение
    /// </summary>
    public class SendingVoiceMessage : SendMessage
    {
        private static string PathVoice { get; } = ConfigurationManager.AppSettings.Get("VoiceFile");

        /// <summary>
        /// Формирует голосовое сообщение.
        /// </summary>
        public override async Task<Message> MessageFromBot(string from, MessageEventArgs args)
        {
            using (var message = System.IO.File.OpenRead(from))
            {
                return await InitializeBot.Client.SendVoiceAsync(
                    chatId: args.Message.Chat.Id,
                    replyToMessageId: args.Message.MessageId,
                    voice: message);
            }
        }

        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public override string SendingMessage(MessageEventArgs args)
        {
            //создание сообщения 
            if (!CreateVoiceMessage.CreateMessage(args.Message.Text).Result) throw new Exception("Произошла ошибка при создании голосового сообщения");

            Message mes = MessageFromBot(PathVoice, args).Result;

            DeleteFileAfterSubmission.DeleteFile();

            return LoggingMessages.LogMess(mes, true);
        }
    }
}
