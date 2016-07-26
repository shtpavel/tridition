using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.Services;
using Tridion.Services.Infrastructure;

namespace Tridion.Tests
{
    [TestClass]
    public class TestsBase
    {
        protected const string Folder = @"./TestFiles/";
        protected readonly IUnityContainer _container;
        public TestsBase()
        {
            _container = new ApplicationContainerBuilder().Build();
        }

        [TestInitialize]
        public void Setup()
        {
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);
        }

        [TestCleanup]
        public void CleanUp()
        {
            foreach (var extension in Constants.Extensions)
            {
                var filesToRemove = Directory.GetFiles(Folder, $"*.{extension}", SearchOption.AllDirectories);
                foreach (var filePath in filesToRemove)
                    File.Delete(filePath);

                var bcpFilesToRemove = Directory.GetFiles(Folder, $"*.{Constants.BackupExtension}", SearchOption.AllDirectories);
                foreach (var bcpFile in bcpFilesToRemove)
                    File.Delete(bcpFile);
            }
        }
    }
}
