using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tridion.Services.Abstract;

namespace Tridion.Services
{
    public class XmlProcessor : IXmlProcessor
    {
        private readonly IXmlRewriter _rewriter;
        private readonly IBackupService _backupService;
        private readonly IFileProcessor _fileProcessor;

        public XmlProcessor(
            IXmlRewriter rewriter, 
            IBackupService backupService, 
            IFileProcessor fileProcessor)
        {
            _rewriter = rewriter;
            _backupService = backupService;
            _fileProcessor = fileProcessor;
        }

        public void Process(string folder)
        {
            var filesToProcess = _fileProcessor.GetFiles(folder);

            foreach (var fileInfo in filesToProcess)
            {
                // 1 - Do backup
                _backupService.Backup(fileInfo);
                
                // 2 - Process file
                var rewrittenXml = String.Empty;
                try
                {
                    rewrittenXml =_rewriter.RewriteXml(fileInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine($"{fileInfo.FullName} is corrupted. Skipping it...");
                    continue;
                }

                // 3 - rewrite
                _fileProcessor.Rewrite(fileInfo, rewrittenXml);
            }
        }
    }
}
