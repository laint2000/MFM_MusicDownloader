using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using MfmTop20Tests.Code.Fakes;
using Moq;
using MfmTop20.Code.Interfaces;

namespace MfmTop20.Code.Tests
{
    [TestClass()]
    public class DownloaderTests
    {
        private Downloader _downloader;
        private List<string> _existingMp3;
        private List<string> _downloadedMp3;


        [TestInitialize]
        public void TestInitialize()
        {
            _existingMp3 = new List<string>()
            {
                "Music_00.mp3",
                "Music_01.mp3"
            };

            _downloadedMp3 = new List<string>()
            {
                "http://mfm.ua/Music_00.mp3",
                "http://mfm.ua/Music_01.mp3",
                "http://mfm.ua/Music_02.mp3",
                "http://mfm.ua/Music_03.mp3"
            };

            var fakeConnector = new FakeHttpConnector();
            var fakeParser = new Mock<IHtmlParser>();
            fakeParser.Setup(q => q.GetItems(It.IsAny<string>())).Returns(_downloadedMp3);

            var fakeFilesAdapter = new Mock<IMp3FilesAdapter>();
            fakeFilesAdapter.Setup(q => q.ExistedFiles).Returns(_existingMp3);
            fakeFilesAdapter.Setup(q => q.SaveToFile(It.IsAny<string>(), It.IsAny<Stream>())).Returns(true);

            _downloader = new Downloader(fakeConnector, fakeParser.Object, fakeFilesAdapter.Object);
        }

        [TestMethod()]
        public void GetNewSongs_ReturnsListExceptExistingsFiles()
        {
            //arrange
            //act
            _downloader.GetNewSongsList();
            
            //assert
            Assert.AreEqual(2, _downloader.NewFilesList.Count, "Invalid count value");
            Assert.AreEqual("Music_02.mp3", _downloader.NewFilesList[0], "Invalid value 0");
            Assert.AreEqual("Music_03.mp3", _downloader.NewFilesList[1], "Invalid value 1");
        }
    }
}