using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using TelegramBot.Messages;
using TelegramBot.Sending;
using VkNet;

namespace TelegramBot
{
    /// <summary>
    /// Определение сообщений ботом.
    /// </summary>
    public class DefiningMessage
    {
        private SendMessage sendMessage;
        /// <summary>
        /// Определение типа сообщения.
        /// </summary>
        public string TypeForMessage(MessageEventArgs args, VkApi auth)
        {
            try
            {
                switch (args.Message.Text)
                {
                    case "/start":
                        sendMessage = new InitializeSending() { };
                        return sendMessage.SendingMessage(args);
                    case "📃 Рандомный анекдот":
                        sendMessage = new SendingTextMessage() { };
                        return sendMessage.SendingMessage(args);
                    case "🎨 Рандомный мем":
                        SendingPhotoMessage sendFromVk = new SendingPhotoMessage() { };
                        return sendFromVk.SendingFromVkMessage(args, auth);
                    default: return null;
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
