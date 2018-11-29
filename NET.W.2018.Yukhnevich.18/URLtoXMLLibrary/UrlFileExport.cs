using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace URLtoXMLLibrary
{
    /// <summary>
    /// Provides methods for exporting files with URL addresses
    /// </summary>
    public class UrlFileExport
    {
        /// <summary>
        /// The name of file with URL addresses
        /// </summary>
        private string fileName;

        /// <summary>
        /// Initialize new instance of UrlFileExport class with given source file name
        /// </summary>
        /// <param name="fileName">The source file name</param>
        public UrlFileExport(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Exports the URL addresses in the source file to XML representation and saves it to given file
        /// </summary>
        /// <param name="xmlFileName">The name of file for saving XML representation</param>
        /// <returns>The URL addresses from source file that can't be represent in XML form</returns>
        public string[] ExportToXml(string xmlFileName)
        {
            var errorStrings = new List<string>();
            var rootElement = new XElement("urlAddresses");
            using (var file = new StreamReader(fileName))
            {
                var converter = new ToXmlConverter();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        rootElement.Add(converter.Convert(ParseUrl.ParseUrlAddress(line)));
                    }
                    catch (ArgumentException)
                    {
                        errorStrings.Add(line);
                    }
                }
            }

            new XDocument(rootElement).Save(xmlFileName);
            return errorStrings.ToArray();
        }
    }
}
