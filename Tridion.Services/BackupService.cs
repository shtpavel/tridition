using System.IO;
using Tridion.Services.Abstract;

namespace Tridion.Services
{
    internal class BackupService : IBackupService
    {
        #region Private methods

        void IBackupService.Backup(FileInfo file)
        {
            File.Copy(file.FullName, $"{file.FullName}.{Constants.BackupExtension}", true);
        }

        void IBackupService.RemoveBackup(FileInfo file)
        {
            File.Delete($"{file.FullName}.{Constants.BackupExtension}");
        }

        #endregion
    }
}