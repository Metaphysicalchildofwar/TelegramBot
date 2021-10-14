using Amazon.Polly;
using System;
using System.Collections.Generic;
using System.Text;
using TextScoring.CreateVoiceMessage;

namespace TextScoring.ChangeVoice
{
    public static class GetTheSelectedName
    {
        public static string VoiceName = VoiceId.Maxim;
        public static string FindSelectedName(string name)
        {
            var _changeName = ProcessTextMessage.TruncateString(name, 7);
            var _namesList = GetAListOfVotes.GetNames();

            var _name = _namesList.Find(x => x == _changeName);
            if (_namesList.Find(x => x == _changeName) == null) 
            {
                return $"Указанного имени не существует, выбранный голос - {VoiceName}.\nИспользуйте команду /names для просмотра доступных голосов";
            }
            else
            {
                VoiceName = _name;
                return $"Голос изменен на {VoiceName}";
            }
        }
    }
}
