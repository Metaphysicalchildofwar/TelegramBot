using System;
using System.Configuration;
using System.IO;

namespace TextScoring.CreateVoiceMessage
{
    /// <summary>
    /// Создание файла .OGG
    /// </summary>
    public class CreateOggFile
    {
        private static string PathVoice { get; } = ConfigurationManager.AppSettings.Get("VoiceFile");

        /// <summary>
        /// Создает файл .OGG
        /// </summary>
        public static bool CreateFile(Stream audioStream)
        {
            try
            {
                using (FileStream fileStream = File.Create(PathVoice))
                {
                    audioStream.CopyTo(fileStream);
                    fileStream.Flush();
                    fileStream.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
