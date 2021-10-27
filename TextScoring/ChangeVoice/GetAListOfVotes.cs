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
            var _names = new List<string>();
            foreach (var n in typeof(VoiceId).GetFields())
            {
                _names.Add(n.Name.ToString());
            }
            return _names;
        }
    }
}
