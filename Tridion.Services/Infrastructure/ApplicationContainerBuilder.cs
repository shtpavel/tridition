using Microsoft.Practices.Unity;
using Tridion.Services.Abstract;

namespace Tridion.Services.Infrastructure
{
    public class ApplicationContainerBuilder
    {
        #region Public methods

        public IUnityContainer Build()
        {
            var container = new UnityContainer();

            container.RegisterType<IFileProcessor, FileProcessor>();
            container.RegisterType<IXmlProcessor, XmlProcessor>();
            container.RegisterType<IXmlRewriter, XmlRewriter>();
            container.RegisterType<IBackupService, BackupService>();

            return container;
        }

        #endregion
    }
}