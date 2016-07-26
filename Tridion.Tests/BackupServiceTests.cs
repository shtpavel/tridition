using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.Services;
using Tridion.Services.Abstract;

namespace Tridion.Tests
{
    [TestClass]
    public class BackupServiceTests : TestsBase
    {
        #region Public methods

        [TestMethod]
        public void Can_do_backup()
        {
            IBackupService bcpService = _container.Resolve<IBackupService>();
            var listOfFileNames = new List<string>();

            //A
            foreach (var extension in Constants.Extensions)
            {
                var name = $"{Folder}{Guid.NewGuid().ToString("N")}.{extension}";
                using (var fileStream = File.Create(name))
                {
                }

                listOfFileNames.Add(name);
            }

            //A
            foreach (var fileName in listOfFileNames)
                bcpService.Backup(new FileInfo(fileName));

            //A
            var bcpFiles = Directory.GetFiles(Folder, $"*.{Constants.BackupExtension}", SearchOption.AllDirectories);

            Assert.AreEqual(listOfFileNames.Count, bcpFiles.Length);
        }

        #endregion
    }
}