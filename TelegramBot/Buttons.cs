using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    /// <summary>
    /// Добавление кнопок боту.
    /// </summary>
    public static class Buttons
    {
        /// <summary>
        /// Создать список кнопок.
        /// </summary>
        public static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton { Text = $"📃 Рандомный анекдот" } },
                    new List<KeyboardButton>{new KeyboardButton { Text = $"🎨 Рандомный мем" } }
                },
                ResizeKeyboard = true
            };
        }
    }
}
