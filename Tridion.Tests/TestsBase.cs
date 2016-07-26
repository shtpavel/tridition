using System.IO;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.Services;
using Tridion.Services.Infrastructure;

namespace Tridion.Tests
{
    [TestClass]
    public class TestsBase
    {
        #region Static fields and constants

        protected const string Folder = @"./TestFiles/";

        #endregion

        #region Fields

        protected readonly IUnityContainer _container;

        #endregion

        #region Constructors

        public TestsBase()
        {
            _container = new ApplicationContainerBuilder().Build();
        }

        #endregion

        #region Public methods

        [TestCleanup]
        public void CleanUp()
        {
            foreach (var extension in Constants.Extensions)
            {
                var filesToRemove = Directory.GetFiles(Folder, $"*.{extension}", SearchOption.AllDirectories);
                foreach (var filePath in filesToRemove)
                    File.Delete(filePath);

                var bcpFilesToRemove = Directory.GetFiles(Folder, $"*.{Constants.BackupExtension}",
                    SearchOption.AllDirectories);
                foreach (var bcpFile in bcpFilesToRemove)
                    File.Delete(bcpFile);
            }
        }

        [TestInitialize]
        public void Setup()
        {
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);
        }

        #endregion
    }
}