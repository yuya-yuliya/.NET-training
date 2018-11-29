using System.Collections.Generic;

namespace URLtoXMLLibrary.Parts
{
    /// <summary>
    /// Represents the URL path part in URL address
    /// </summary>
    public class UrlPath : UrlPart
    {
        /// <summary>
        /// The list of path parts
        /// </summary>
        private List<string> pathes;

        /// <summary>
        /// Initialize new instance of UrlPath class with given enumeration of path parts
        /// </summary>
        /// <param name="pathes">The parts of path</param>
        public UrlPath(IEnumerable<string> pathes)
        {
            this.pathes = new List<string>(pathes);
        }

        /// <summary>
        /// The list of path parts
        /// </summary>
        public List<string> PathParts => new List<string>(this.pathes);

        /// <summary>
        /// Adds the path part
        /// </summary>
        /// <param name="path"></param>
        public void Add(string path)
        {
            this.pathes.Add(path);
        }

        /// <summary>
        /// Removes the path part
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Remove(string path)
        {
            return this.pathes.Remove(path);
        }
    }
}
