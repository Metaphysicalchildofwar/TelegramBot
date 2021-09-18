using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TelegramBot
{
    /// <summary>
    /// Парсинг анекдота с сайта.
    /// </summary>
    public static class ParsingAneks
    {
        private static string Html { get; set; }
        private static Regex Reg { get; set; }
        private static MatchCollection Collection { get; set; }

        /// <summary>
        /// Получение текста анекдота со страницы.
        /// </summary>
        public static string ParsAnek()
        {
            Html = ParsHtml();
            Reg = new Regex(@"(?<=<meta name=" + "\"description\" content=\")" + @"([\s\S]*?)(?=" + "\">)");
            Collection = Reg.Matches(Html);
            if (Collection.Count > 0)
            {
                return Collection.FirstOrDefault().Value;
            }
            else
            {
                return "Анека не будет.";
            }
        }

        /// <summary>
        /// Получение разметки страницы.
        /// </summary>
        public static string ParsHtml()
        {
            using (var Client = new WebClient { Encoding = Encoding.Default })
            {
                return Client.DownloadString(ConfigurationManager.AppSettings.Get("SiteAneks"));
            }
            
        }
    }
}
