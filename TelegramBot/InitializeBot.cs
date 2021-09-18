using Telegram.Bot;
using System.Configuration;
using System.Collections.Specialized;

namespace TelegramBot
{
    /// <summary>
    /// Инициализация бота с помощью токена.
    /// </summary>
    public static class InitializeBot
    {
        private static string Token { get; } = ConfigurationManager.AppSettings.Get("TelegramBotToken");
        public static TelegramBotClient Client = new TelegramBotClient(Token);
    }
}
