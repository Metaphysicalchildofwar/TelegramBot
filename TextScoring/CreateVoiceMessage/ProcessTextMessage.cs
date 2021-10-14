namespace TextScoring.CreateVoiceMessage
{
    /// <summary>
    /// Обрезка строки для получения текста
    /// </summary>
    public static class ProcessTextMessage
    {
        /// <summary>
        /// Удалить из строки начальные символы команды
        /// </summary>
        public static string TruncateString(string message, int count)
        {
            return message.Substring(count).Trim();
        }
    }
}
