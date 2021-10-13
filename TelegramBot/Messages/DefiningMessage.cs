using System;
using Telegram.Bot.Args;
using TelegramBot.Messages.TextMessages;
using TelegramBot.Messages.VoiceMessages;

namespace TelegramBot.Messages
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
        public string TypeForMessage(MessageEventArgs args)
        {
            try
            {
                if (args.Message.Text?.Substring(0, 4) == "/say")
                {
                    sendMessage = new SendingVoiceMessage() { };
                    return sendMessage.SendingMessage(args);
                }

                switch (args.Message.Text)
                {                    
                    case "/anek":
                        sendMessage = new SendingTextMessage() { };
                        return sendMessage.SendingMessage(args);
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
