using ParseVkMemes;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using VkNet;

namespace TelegramBot.Sending
{
    /// <summary>
    /// Отправка изображений.
    /// </summary>
    public class SendingPhotoMessage : SendMessage
    {
        /// <summary>
        /// Формирует текстовое сообщение.
        /// </summary>
        public override async Task<Message> MessageFromBot(string from, MessageEventArgs args)
        {

            return await InitializeBot.Client.SendPhotoAsync(
               args.Message.Chat.Id,
               photo: from,
               replyToMessageId: args.Message.MessageId,
               parseMode: ParseMode.Markdown,
               replyMarkup: Buttons.GetButtons());
        }


        /// <summary>
        /// Метод отправки сообщений бота.
        /// (Пока что не используется)
        /// </summary>
        public override string SendingMessage(MessageEventArgs args)
        {
            try
            {
                Message mes = MessageFromBot(String.Empty, args).Result;
                return LoggingMessages.LogMess(mes, true);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Метод отправки картинки ботом из ВК.
        /// </summary>
        public string SendingFromVkMessage(MessageEventArgs args, VkApi auth)
        {
            Message mes = MessageFromBot(SearchImage(auth), args).Result;
            return LoggingMessages.LogMess(mes, true);
        }

        /// <summary>
        /// Метод отправки картинки ботом из ВК.
        /// </summary>
        private string SearchImage(VkApi auth)
        {
            var photos = MethodsForVk.GettingPhotos(auth).ToList();
            return photos[new Random().Next(photos.Count)].Sizes[6].Url.AbsoluteUri.ToString(); 
        }
    }
}
