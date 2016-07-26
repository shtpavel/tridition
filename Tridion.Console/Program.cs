using System.IO;
using Microsoft.Practices.Unity;
using Tridion.Services.Abstract;
using Tridion.Services.Infrastructure;

namespace Tridion.Console
{
    internal class Program
    {
        #region Private methods

        private static void Main(string[] args)
        {
            var container = new ApplicationContainerBuilder().Build();
            var processor = container.Resolve<IXmlProcessor>();
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please specify directory...");
                System.Console.ReadKey();
                return;
            }

            string path = args[0];
            if (Directory.Exists(path))
                processor.Process(path);
            else
                System.Console.WriteLine("Path not found");
        }

        #endregion
    }
}