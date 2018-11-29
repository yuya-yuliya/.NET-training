using System;
using System.IO;
using URLtoXMLLibrary;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"test.txt",
                xmlFileName = @"test.xml";

            var export = new UrlFileExport(fileName);
            string[] errorUrl = export.ExportToXml(xmlFileName);

            Console.WriteLine(File.ReadAllText(xmlFileName));
            Console.WriteLine("Error URLs:");
            Console.WriteLine($"\t{string.Join("\n\r\t", errorUrl)}");
            Console.ReadLine();
        }
    }
}
