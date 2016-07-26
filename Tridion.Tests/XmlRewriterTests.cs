using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.Services.Abstract;

namespace Tridion.Tests
{
    [TestClass]
    public class XmlRewriterTests : TestsBase
    {
        #region Public methods

        [TestMethod]
        public void Can_Process_Xml()
        {
            var testInput =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?><test title = \"This Tridion will be updated\" ><line1> Tridion has been renamed to SDL Tridion</line1 ></test > ";
            var testOutput =
                "<?xml version=\"1.0\" encoding=\"utf-16\"?><test title = \"This SDL Tridion will be updated\" ><line1> SDL Tridion has been renamed to SDL Tridion</line1 ></test > ";

            IFileProcessor reader = _container.Resolve<IFileProcessor>();
            IXmlRewriter processor = _container.Resolve<IXmlRewriter>();

            var output = processor.RewriteXml(testInput.Trim());

            Assert.AreEqual(
                string.Join("", output.ToLower().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)),
                string.Join("", testOutput.ToLower().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)));
        }

        #endregion
    }
}