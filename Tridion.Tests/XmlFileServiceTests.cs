using System;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.Services;
using Tridion.Services.Abstract;

namespace Tridion.Tests
{
    [TestClass]
    public class XmlFileServiceTests : TestsBase
    {
        [TestMethod]
        public void Can_get_files_from_directory()
        {
            IFileProcessor reader = _container.Resolve<IFileProcessor>();

            //A
            foreach (var extension in Constants.Extensions)
            {
                using (var fileStream = File.Create($"{Folder}{Guid.NewGuid().ToString("N")}.{extension}"))
                {
                }
            }
                
            //A
            var files = reader.GetFiles(Folder);

            //A
            Assert.AreEqual(files.Length, Constants.Extensions.Length);
        }

        
    }
}
