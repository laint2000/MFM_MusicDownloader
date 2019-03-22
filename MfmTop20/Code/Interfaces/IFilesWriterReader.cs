using System.Collections.Generic;
using System.IO;

namespace MfmTop20.Code.Interfaces
{
    public interface IFilesWriterReader
    {
        List<string> GetStringList(string fileName);
        void SaveToFile(string path, string fileName, Stream stream);
        void SaveList(string fileName, List<string> list);
        List<string> GetMp3FilesList(string mp3Folder);
    }
}