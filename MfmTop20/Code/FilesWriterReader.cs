using MfmTop20.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MfmTop20.Code
{
    public class FilesWriterReader : IFilesWriterReader
    {
        public List<string> GetStringList(string fileName)
        {
            if (!File.Exists(fileName))
                return new List<string>();

            return File.ReadAllLines(fileName).ToList();
        }

        public void SaveToFile(string path, string fileName, Stream stream)
        {
            Directory.CreateDirectory(path);
            var fullFileName = $"{path}\\{fileName}";

            if (File.Exists(fullFileName)) { File.Delete(fullFileName); }

            using (var fileStream = new FileStream(fullFileName, FileMode.CreateNew))
            {
                stream.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        public void SaveList(string fileName, List<string> list)
        {
            File.WriteAllLines(fileName, list);
        }

        public List<string> GetMp3FilesList(string mp3Folder)
        {
            try
            {
                var filesList = Directory.GetFiles(mp3Folder, "*.mp3").ToList();
                return filesList.Select(r => Path.GetFileName(r)).ToList();
            }
            catch (Exception)
            {
            }

            return new List<string>();            
        }

    }
}
