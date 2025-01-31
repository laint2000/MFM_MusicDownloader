﻿using System;
using System.IO;
using MfmTop20.Code.Interfaces;
using MfmTop20.Code.Tests;

namespace MfmTop20Tests.Code.Fakes
{

    internal class FakeHttpConnector : IHttpConnectror
    {
        public event Action<string> OnLoadStringComplete;
        public event Action<string, Stream> OnLoadStreamComplete;

        public Stream LoadStream(string url)
        {
            const string content = "Mp3 test content";
            var result = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));
            OnLoadStreamComplete(url, result);

            return result;
        }

        public string LoadString(string url)
        {
            var responseString = File.ReadAllText(Const.FileHtmlTop20Page);

            OnLoadStringComplete(responseString);
            return responseString;
        }
    }
}
