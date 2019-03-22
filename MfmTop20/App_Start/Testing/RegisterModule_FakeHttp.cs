using MfmTop20.Code;
using MfmTop20.Code.Fakes;
using MfmTop20.Code.Interfaces;
using Ninject.Modules;

namespace MfmTop20.App_Start.Testing
{
    internal class RegisterModule_FakeHttp : NinjectModule
    {
        public override void Load()
        {
            Bind<IDownloader>().To<Downloader>();
            Bind<IHttpConnectror>().To<HttpTestConnector>();
            Bind<IHtmlParser>().To<Mfm20Parser>();
            Bind<IFilesWriterReader>().To<FilesWriterReader>();
            Bind<IMp3FilesAdapter>().To<Mp3FilesAdapter>();
        }
    }
}