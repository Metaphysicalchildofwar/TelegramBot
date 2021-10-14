using Amazon.Polly;
using System.Collections.Generic;

namespace TextScoring.ChangeVoice
{
    /// <summary>
    /// Получает список всех голосов
    /// </summary>
    public static class GetAListOfVotes
    {
        /// <summary>
        /// Получает имена
        /// </summary>
        public static List<string> GetNames()
        {
            var names = new List<string>();
            foreach (var i in typeof(VoiceId).GetProperties())
            {
                names.Add(i.Name);
            }
            return names;
        }
    }
}
