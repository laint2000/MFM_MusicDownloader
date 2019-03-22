using System.Collections.Generic;

namespace MfmTop20.Code.Interfaces
{
    public interface IHtmlParser
    {
        List<string> GetItems(string htmlText);
    }
}