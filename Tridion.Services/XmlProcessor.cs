using System;
using Tridion.Services.Abstract;

namespace Tridion.Services
{
    /// <summary>
    /// main xml processor app service.
    /// Implements the strategy to rewrite required stuff.
    /// </summary>
    public class XmlProcessor : IXmlProcessor
    {
        #region Fields

        private readonly IBackupService _backupService;
        private readonly IFileProcessor _fileProcessor;
        private readonly IXmlRewriter _rewriter;

        #endregion

        #region Constructors

        public XmlProcessor(
            IXmlRewriter rewriter,
            IBackupService backupService,
            IFileProcessor fileProcessor)
        {
            _rewriter = rewriter;
            _backupService = backupService;
            _fileProcessor = fileProcessor;
        }

        #endregion

        #region Public methods

        public void Process(string folder)
        {
            var filesToProcess = _fileProcessor.GetFiles(folder);

            foreach (var fileInfo in filesToProcess)
            {
                // 1 - Do backup
                _backupService.Backup(fileInfo);

                // 2 - Process file
                string rewrittenXml;
                try
                {
                    rewrittenXml = _rewriter.RewriteXml(fileInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine($"{fileInfo.FullName} is corrupted. Skipping it...");
                    _backupService.RemoveBackup(fileInfo);
                    continue;
                }

                // 3 - rewrite
                _fileProcessor.Rewrite(fileInfo, rewrittenXml);
            }
        }

        #endregion
    }
}