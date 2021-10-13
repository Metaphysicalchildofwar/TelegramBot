using System.Configuration;
using Telegram.Bot;

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
