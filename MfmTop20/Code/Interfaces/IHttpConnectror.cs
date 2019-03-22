using System;
using System.IO;

namespace MfmTop20.Code.Interfaces
{
    public interface IHttpConnectror
    {
        event Action<string> OnLoadStringComplete;
        event Action<string, Stream> OnLoadStreamComplete;
        string LoadString(string url);
        Stream LoadStream(string url);
    }
}