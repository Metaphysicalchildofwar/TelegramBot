using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;

namespace TelegramBot.Messages
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(MessageEventArgs args);
    }
}
