using System.IO;

namespace Tridion.Services.Abstract
{
    public interface IXmlRewriter
    {
        #region Public methods

        string RewriteXml(FileInfo file);
        string RewriteXml(string xmlContent);

        #endregion
    }
}