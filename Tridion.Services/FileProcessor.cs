using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tridion.Services.Abstract;

namespace Tridion.Services
{
    internal class FileProcessor : IFileProcessor
    {
        #region Public methods

        public FileInfo[] GetFiles(string dir)
        {
            return GetFiles(new DirectoryInfo(dir));
        }

        public FileInfo[] GetFiles(DirectoryInfo dir)
        {
            var fileInfoList = new List<FileInfo>();
            foreach (var extension in Constants.Extensions)
            {
                var files = dir.GetFiles($"*.{extension}", SearchOption.AllDirectories);
                foreach (var fileInfo in files)
                {
                    if (!fileInfoList.Any(x => x.FullName == fileInfo.FullName))
                    {
                        fileInfoList.Add(fileInfo);
                    }
                }
            }

            return fileInfoList.ToArray();
        }

        public void Rewrite(FileInfo file, string text)
        {
            using (FileStream fs = new FileStream(file.FullName, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(text);
                }
            }
        }

        #endregion
    }
}