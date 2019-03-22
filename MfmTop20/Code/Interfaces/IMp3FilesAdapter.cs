using System.Collections.Generic;
using System.IO;

namespace MfmTop20.Code.Interfaces
{
    public interface IMp3FilesAdapter
    {
        List<string> ExistedFiles { get; }
        bool SaveToFile(string fileName, Stream stream);
    }
}