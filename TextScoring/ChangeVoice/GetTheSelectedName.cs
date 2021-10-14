using System;
using System.Collections.Generic;
using System.Text;
using TextScoring.CreateVoiceMessage;

namespace TextScoring.ChangeVoice
{
    public static class GetTheSelectedName
    {
        public static void FindSelectedName(string name)
        {
            var _changeName = ProcessTextMessage.TruncateString(name, 7);
            var _namesList = GetAListOfVotes.GetNames();

            var _name = _namesList.Find(x => x == _changeName);


        }
    }
}
