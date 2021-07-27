using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
namespace TelegramBot
{
    /// <summary>
    /// Отправка сообщений ботом.
    /// </summary>
    public static class SendingMessages
    {
        /// <summary>
        /// Метод отправки сообщений бота.
        /// </summary>
        public static async Task<string> SendMessage(MessageEventArgs args)
        {
            if (args.Message.Text != null)
            {
                if (args.Message.Text.ToLower().IndexOf("анек") != -1 && args.Message.Type == MessageType.Text)
                {
                    Message mes = MessageFromBot(ParsingAneks.ParsAnek(), args).Result;
                    return LoggingMessages.LogMess(mes, true);
                }
                else
                {
                    Message mes = MessageFromBot("Если хочешь анекдот, напиши \"анек\"", args).Result;
                    return LoggingMessages.LogMess(mes, true);
                }
            }
            else
            {
                Message mes = MessageFromBot("Если хочешь анекдот, напиши \"анек\"", args).Result;
                return LoggingMessages.LogMess(mes, true);
            }
        }

        /// <summary>
        /// Формирует логирование сообщения.
        /// </summary>
        public async static Task<Message> MessageFromBot(string from, MessageEventArgs args)
        {
            return await InitializeBot.Client.SendTextMessageAsync(args.Message.Chat.Id, from, replyToMessageId: args.Message.MessageId, parseMode: ParseMode.Markdown);
        }
    }
}
