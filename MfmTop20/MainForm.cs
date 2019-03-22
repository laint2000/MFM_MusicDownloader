using System;
using System.Linq;
using System.Windows.Forms;
using MfmTop20.Code;
using MfmTop20.Code.Interfaces;

namespace MfmTop20
{
    public partial class MainForm : Form
    {

        private readonly IDownloader _downloader;
        //private readonly Downloader _downloader;
        public MainForm(IDownloader downloader)
        {
            InitializeComponent();

            //_downloader = Factory.CreateDownloader();
            _downloader = Factory.CreateTestDownloader();
            //_downloader = Factory.CreateTestDownloaderWithErrors();

            _downloader = downloader;
            if (_downloader == null) {
                txtConsole.AppendText($"Error => _downloader is empty \r\n");
                return;
            }

            _downloader.OnNewSongsListGet += downloader_OnNewSongsListGet;
            _downloader.OnDownloadMusicFile += downloader_OnDownloadMusicFile; 
            _downloader.AfterDownloadAllComplete += downloader_AfterDownloadAllComplete;

            btnRefresh_Click(null, null);
        }


        private void downloader_OnNewSongsListGet(bool isSuccesfull, string errorMsg)
        {
            if (!isSuccesfull) {
                txtConsole.AppendText($"Error: {errorMsg} \r\n");
                return;
            }

            if (_downloader.NewFilesList.Count <= 0)
            {
                txtConsole.AppendText($"No new songs \r\n");
                return;
            }

            var textToShow = string.Join("\r\n", _downloader.NewFilesList);
            txtConsole.AppendText($"New songs to download \r\n{textToShow}\r\n");
        }

        private void downloader_OnDownloadMusicFile(string url, bool isSuccesfull, string errorMsg)
        {
            RunInMainStream(() => ShowDownloadMusicFileInformation(url, isSuccesfull, errorMsg));
        }

        private void downloader_AfterDownloadAllComplete()
        {
            RunInMainStream(() => ShowDownloadCompleteInformation());
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "";
            if (_downloader.NewSongsList.Count == 0)
            {
                txtConsole.AppendText($"No new music to download \r\n");
                return;
            }

            _downloader.DownloadAllMp3();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "Loading new songs list \r\n\r\n";
            _downloader.GetNewSongsList();
        }

        private void RunInMainStream(Action methodToRun)
        {
            // this is used to call method from other thread in main thread
            this.Invoke(new MethodInvoker(methodToRun));
        }

        private void ShowDownloadMusicFileInformation(string url, bool isSuccesfull, string errorMsg) {
            var fileName = url.UrlFileNameOnly();

            if (!isSuccesfull)
            {
                txtConsole.AppendText($"Error: {fileName} \r\n" +
                                      $"       {errorMsg} \r\n");
                return;
            }

            txtConsole.AppendText($"File saved: {fileName} \r\n");
        }

        private void ShowDownloadCompleteInformation()
        {
            txtConsole.AppendText("\r\n\r\n");
            txtConsole.AppendText("Download complete \r\n");
        }
    }
}
