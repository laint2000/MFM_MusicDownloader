using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MfmTop20.Code
{
    public class Mfm20Parser : IHtmlParser
    {
        private const string HttpSite = "http://mfm.ua/";
        private const string RegExpPattern = @"<a class=""track sp-play-track"" href=""(.+?\.mp3)""";

        public List<string> GetItems(string htmlText)
        {
            var result = new List<string>();
            var groups = Regex.Matches(htmlText, RegExpPattern);

            foreach (Match match in groups)
            {
                if (match.Groups.Count < 2) continue;

                var mp3File = match.Groups[1].Value.Trim();
                var mp3FullUrl = GetFullUrlName(mp3File);
                result.Add(mp3FullUrl);
            }

            return result;
        }

        private string GetFullUrlName(string urlName)
        {
            if (urlName.ToLower().StartsWith("http"))
            {
                return urlName;
            }

            var urlSuffix = urlName.StartsWith("/")
                ? urlName.Remove(0, 1)
                : urlName;

            return HttpSite + urlSuffix;
        }
    }
}