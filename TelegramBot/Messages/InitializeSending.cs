using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Sending;

namespace TelegramBot.Messages
{
    public class InitializeSending : SendMessage
    {
        /// <summary>
        /// Формирует текстовое сообщение.
        /// </summary>
        public override async Task<Message> MessageFromBot(string from, MessageEventArgs args)
        {
            return await InitializeBot.Client.SendTextMessageAsync(
                args.Message.Chat.Id,
                from,
                replyToMessageId: 
                args.Message.MessageId, 
                replyMarkup: Buttons.GetButtons());

        }

        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public override string SendingMessage(MessageEventArgs args)
        {
            Message mes = MessageFromBot("Вывод кнопок", args).Result;
            return LoggingMessages.LogMess(mes, true);
        }
    }
}
