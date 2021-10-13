using Telegram.Bot.Args;

namespace TelegramBot.Messages.Handlers
{
    /// <summary>
    /// Абстрактный обработчик для определения типа сообщения
    /// </summary>
    abstract class AbstractHandler : IHandler
    {
        /// <summary>
        /// Следующий обработчик
        /// </summary>
        private IHandler _nextHandler;

        /// <summary>
        /// Установить следующего обработчика
        /// </summary>
        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        /// <summary>
        /// Обработать запрос (если есть обработчик)
        /// </summary>
        public virtual object Handle(MessageEventArgs args)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.Handle(args);
            }
            else
            {
                return null;
            }
        }
    }
}
