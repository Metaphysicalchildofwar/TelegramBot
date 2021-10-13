namespace TextScoring.CreateVoiceMessage
{
    /// <summary>
    /// Обрезка строки для получения голосового
    /// </summary>
    public static class ProcessTextMessage
    {
        /// <summary>
        /// Удалить из строки начальные символы '\say'
        /// </summary>
        public static string TruncateString(string message)
        {
            return message.Substring(4);
        }
    }
}
