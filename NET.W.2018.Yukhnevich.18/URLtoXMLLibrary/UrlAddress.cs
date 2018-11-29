using System.Collections.Generic;

namespace URLtoXMLLibrary
{
    /// <summary>
    /// Represents the URL address
    /// </summary>
    public class UrlAddress
    {
        /// <summary>
        /// The parts of URL address
        /// </summary>
        private List<UrlPart> parts;

        /// <summary>
        /// Initialize new instance of UrlAddress class
        /// </summary>
        public UrlAddress() : this(null)
        {
        }

        /// <summary>
        /// Initialize new instance of UrlAddress class with URL parts copied from given enumeration
        /// </summary>
        public UrlAddress(IEnumerable<UrlPart> parts)
        {
            this.parts = parts == null ? new List<UrlPart>() : new List<UrlPart>(parts);
        }

        /// <summary>
        /// The parts of URL address
        /// </summary>
        public IEnumerable<UrlPart> Parts
        {
            get
            {
                return new List<UrlPart>(parts);
            }
        }

        /// <summary>
        /// Adds the part in URL address
        /// </summary>
        /// <param name="part"></param>
        public void Add(UrlPart part)
        {
            parts.Add(part);
        }

        /// <summary>
        /// Removes the part from URL address
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool Remove(UrlPart part)
        {
            return parts.Remove(part);
        }
    }
}
