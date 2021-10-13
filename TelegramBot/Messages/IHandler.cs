using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;

namespace TelegramBot.Messages
{
    /// <summary>
    /// Интерфейс обработчика для определения типа сообщения
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Следующий обработчик
        /// </summary>
        IHandler SetNext(IHandler handler);

        /// <summary>
        /// Обработать запрос (если есть обработчик)
        /// </summary>
        object Handle(MessageEventArgs args);
    }
}
