using Telegram.Bot;

namespace TelegramBot
{
    /// <summary>
    /// Инициализация бота с помощью токена.
    /// </summary>
    public static class InitializeBot
    {
        private static string Token { get; } = "1908202643:AAEObGX8meJ0xivUZKj_g20Bjbi8pfyY9ns";
        public static TelegramBotClient Client = new TelegramBotClient(Token);
    }
}
