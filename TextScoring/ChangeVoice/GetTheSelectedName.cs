﻿using Amazon.Polly;
using System;
using System.Collections.Generic;
using System.Text;
using TextScoring.CreateVoiceMessage;

namespace TextScoring.ChangeVoice
{
    public static class GetTheSelectedName
    {
        public static string VoiceName = "Maxim";
        public static string FindSelectedName(string name)
        {
            var _changeName = ProcessTextMessage.TruncateString(name, 7);
            var _namesList = GetAListOfVotes.GetNames();

            var _name = _namesList.Find(x => x == _changeName);
            if (_namesList.Find(x => x == _changeName) == null) 
            {
                return "Указанного имени не существует";
            }
            else
            {
                VoiceName = _name;
                return "Голос изменен";
            }
        }
    }
}
