using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string html;
            using (var Client = new WebClient { Encoding = Encoding.Default })
            {
                html = Client.DownloadString("https://baneks.ru/random");

            }
            Regex regex = new Regex(@"(?<=<meta name=" + "\"description\" content=\")" + @"([\s\S]*?)(?=" + "\">)");
            MatchCollection collection = regex.Matches(html);

            if (collection.Count > 0)
            {
                Console.WriteLine(collection[0].Value);
            }
            else
            {
                Console.WriteLine("Анека не будет.");
            }
            Console.Read();
        }
    }
}
