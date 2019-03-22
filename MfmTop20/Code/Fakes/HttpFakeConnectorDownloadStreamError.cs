using MfmTop20.Code.Interfaces;
using System;
using System.IO;

namespace MfmTop20.Code.Fakes
{
    internal class HttpFakeConnectorDownloadStreamError : IHttpConnectror
    {
        public event Action<string> OnLoadStringComplete = delegate { };
        public event Action<string, Stream> OnLoadStreamComplete = delegate { };

        public Stream LoadStream(string url)
        {
            const string content = "Mp3 test content";
            var result = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));

            throw new Exception($"file not found: {url}");

            //OnLoadStreamComplete(url, result);

            //return result;
        }

        public string LoadString(string url)
        {
            var responseString = File.ReadAllText(@"../../TestDataFiles/top20.html");

            OnLoadStringComplete(responseString);
            return responseString;
        }
    }
}