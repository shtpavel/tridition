using System.IO;

namespace Tridion.Services.Abstract
{
    public interface IFileProcessor
    {
        #region Public methods

        FileInfo[] GetFiles(string dir);
        FileInfo[] GetFiles(DirectoryInfo dir);
        void Rewrite(FileInfo file, string text);

        #endregion
    }
}