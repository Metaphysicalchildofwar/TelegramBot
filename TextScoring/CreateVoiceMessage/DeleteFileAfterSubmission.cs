using System.Configuration;

namespace TextScoring.CreateVoiceMessage
{
    /// <summary>
    /// Удаление файла после отправки.
    /// </summary>
    public static class DeleteFileAfterSubmission
    {
        private static string PathVoice { get; } = ConfigurationManager.AppSettings.Get("VoiceFile");
        public static void DeleteFile()
        {
            System.IO.File.Delete(PathVoice);

        }
    }
}
