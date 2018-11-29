using System.Xml.Linq;
using URLtoXMLLibrary.Parts;

namespace URLtoXMLLibrary
{
    /// <summary>
    /// Provides methods for converting the URL address to XML element
    /// </summary>
    public class ToXmlConverter
    {
        /// <summary>
        /// Converts the URL address to XML element
        /// </summary>
        /// <param name="urlAddress">The Url address</param>
        /// <returns>The XML element, that represents given UML address</returns>
        public XElement Convert(UrlAddress urlAddress)
        {
            var element = new XElement("urlAddress");

            foreach (dynamic urlPart in urlAddress.Parts)
            {
                element.Add(PartToElement(urlPart));
            }

            return element;
        }

        /// <summary>
        /// Converts the URL part to XML element
        /// </summary>
        /// <param name="part">The part of URL</param>
        /// <returns>The XML element, that represents given UML part</returns>
        private XElement PartToElement(UrlPart part)
        {
            return new XElement("part");
        }

        /// <summary>
        /// Converts the URL parameters to XML element
        /// </summary>
        /// <param name="parameters">The URL parameters</param>
        /// <returns>The XML element, that represents given UML parameters</returns>
        private XElement PartToElement(Parameters parameters)
        {
            var element = new XElement("parameters");
            foreach (var param in parameters.ParametersList)
            {
                element.Add(PartToElement(param));
            }

            return element;
        }

        /// <summary>
        /// Converts the URL scheme to XML element
        /// </summary>
        /// <param name="scheme">The URL scheme</param>
        /// <returns>The XML element, that represents given UML scheme</returns>
        private XElement PartToElement(Scheme scheme)
        {
            return new XElement("scheme", new XAttribute("name", scheme.Name));
        }

        /// <summary>
        /// Converts the URL path to XML element
        /// </summary>
        /// <param name="path">The URL path</param>
        /// <returns></returns>
        private XElement PartToElement(UrlPath path)
        {
            var element = new XElement("uri");
            foreach (var pathPart in path.PathParts)
            {
                element.Add(new XElement("segment", pathPart));
            }

            return element;
        }

        /// <summary>
        /// Converts the URL single parameter to XML element
        /// </summary>
        /// <param name="parameter">The URL single parameter</param>
        /// <returns>The XML element, that represents given UML single parameter</returns>
        private XElement PartToElement(Parameter parameter)
        {
            return new XElement("parametr", new XAttribute("key", parameter.Key), new XAttribute("value", parameter.Value));
        }

        /// <summary>
        /// Converts the URL host to XML element
        /// </summary>
        /// <param name="host">The URL host</param>
        /// <returns>The XML element, that represents given UML host</returns>
        private XElement PartToElement(Host host)
        {
            return new XElement("host", new XAttribute("name", host.Name));
        }
    }
}
