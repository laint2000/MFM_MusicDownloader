using System;
using System.IO;
using MfmTop20.Code;

namespace MfmTop20.Fakes
{
    internal class HttpFakeConnectorConnectionErrors : IHttpConnectror
    {
        public event Action<string> OnLoadStringComplete = delegate { };
        public event Action<string, Stream> OnLoadStreamComplete = delegate { };

        public Stream LoadStream(string url)
        {
            throw new Exception($"Connection error");
        }

        public string LoadString(string url)
        {
            throw new Exception($"Connection error");
        }
    }
}