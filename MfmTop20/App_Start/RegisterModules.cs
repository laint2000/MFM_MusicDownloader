using MfmTop20.Code;
using MfmTop20.Code.Interfaces;
using Ninject.Modules;

namespace MfmTop20.App_Start
{
    internal class RegisterModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDownloader>().To<Downloader>();
            Bind<IHttpConnectror>().To<HttpConnector>();
            Bind<IHtmlParser>().To<Mfm20Parser>();
            Bind<IFilesWriterReader>().To<FilesWriterReader>();
            Bind<IMp3FilesAdapter>().To<Mp3FilesAdapter>();
        }        
    }
}