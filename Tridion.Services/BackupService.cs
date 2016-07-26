using System.IO;
using Tridion.Services.Abstract;

namespace Tridion.Services
{
    class BackupService : IBackupService
    {
        void IBackupService.Backup(FileInfo file)
        {
            File.Copy(file.FullName, $"{file.FullName}.{Constants.BackupExtension}", true);
        }
    }
}
