using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Tridion.Services.Abstract;

namespace Tridion.Services.Infrastructure
{
    public class ApplicationContainerBuilder
    {
        public IUnityContainer Build()
        {
            var container = new UnityContainer();

            container.RegisterType<IFileProcessor, FileProcessor>();
            container.RegisterType<IXmlProcessor, XmlProcessor>();
            container.RegisterType<IXmlRewriter, XmlRewriter>();
            container.RegisterType<IBackupService, BackupService>();

            return container;
        }
    }
}
