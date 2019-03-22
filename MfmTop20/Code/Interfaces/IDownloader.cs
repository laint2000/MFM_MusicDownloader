using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MfmTop20.Code.Interfaces
{
    public interface IDownloader
    {
        List<string> ErrorMessages { get; }
        List<string> NewFilesList { get; }
        List<string> NewSongsList { get; }

        event Action AfterDownloadAllComplete;
        event Action<string, bool, string> OnDownloadMusicFile;
        event Action<bool, string> OnNewSongsListGet;

        void DownloadAllMp3();
        void GetNewSongsList();
    }
}
