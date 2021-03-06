﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Tridion.Services.Abstract;

namespace Tridion.Services
{
    internal class XmlRewriter : IXmlRewriter
    {
        private const string Pattern = @"(?:(?<!SDL )Tridion)";
        private const string ReplaceToPattern = "SDL Tridion";

        public string RewriteXml(FileInfo file)
        {
            XDocument doc = XDocument.Load(file.FullName);

            return ProcessXml(doc);
        }

        public string RewriteXml(string xmlContent)
        {
            return ProcessXml(XDocument.Parse(xmlContent));
        }

        private string ProcessXml(XDocument doc)
        {
            var attributes = doc.Descendants().Attributes("title");
            foreach (var xAttribute in attributes)
                xAttribute.Value = DoReplace(xAttribute.Value);

            var nodes = doc
                .XPathSelectElements("//*[contains(text(), 'Tridion')]");

            //Replace texts
            foreach (var xElement in nodes)
                xElement.Value = DoReplace(xElement.Value);

            StringBuilder builder = new StringBuilder();
            using (TextWriter writer = new StringWriter(builder))
                doc.Save(writer);

            return builder.ToString();
        }

        private string DoReplace(string text)
        {
            return Regex.Replace(text, Pattern, ReplaceToPattern, RegexOptions.IgnoreCase);
        }
    }
}
