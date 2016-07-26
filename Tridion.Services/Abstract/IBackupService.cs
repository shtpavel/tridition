using System.IO;

namespace Tridion.Services.Abstract
{
    public interface IBackupService
    {
        #region Public methods

        void Backup(FileInfo file);
        void RemoveBackup(FileInfo file);

        #endregion
    }
}