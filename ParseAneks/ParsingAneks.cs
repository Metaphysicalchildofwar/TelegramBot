using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ParseAneks
{
    /// <summary>
    /// Парсинг анекдота с сайта.
    /// </summary>
    public static class ParsingAneks
    {
        private static string Html { get; set; }
        private static Regex Reg { get; set; } = new Regex(@"(?<=<meta name=" + "\"description\" content=\")" + @"([\s\S]*?)(?=" + "\">)");
        private static MatchCollection Collection { get; set; }

        /// <summary>
        /// Получение текста анекдота со страницы.
        /// </summary>
        public static string ParsAnek()
        {
            Html = ParsHtml();
            Collection = Reg.Matches(Html);
            return Collection.FirstOrDefault()?.Value;            
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
