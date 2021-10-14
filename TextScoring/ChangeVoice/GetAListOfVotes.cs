using Amazon.Polly;
using System.Collections.Generic;
using System.Reflection;

namespace TextScoring.ChangeVoice
{
    /// <summary>
    /// Получает список всех голосов
    /// </summary>
    internal static class GetAListOfVotes
    {
        /// <summary>
        /// Получает имена
        /// </summary>
        public static List<string> GetNames()
        {
            var _names = new List<string>();

            var info = typeof(VoiceId).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            for(var i = 0; i < info.Length; i++)
            {
                _names.Add(info[i].ToString());
            }
            return _names;
        }
    }
}
