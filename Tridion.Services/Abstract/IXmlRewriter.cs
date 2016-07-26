using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Tridion.Services.Abstract
{
    public interface IXmlRewriter
    {
        string RewriteXml(FileInfo file);
        string RewriteXml(string xmlContent);
    }
}
