namespace URLtoXMLLibrary.Parts
{
    /// <summary>
    /// Represents the scheme part in URL address
    /// </summary>
    public class Scheme : UrlPart
    {
        /// <summary>
        /// Initialize new instance of Scheme class with given scheme name
        /// </summary>
        /// <param name="schemeName">The name of scheme</param>
        public Scheme(string schemeName)
        {
            this.Name = schemeName;
        }

        /// <summary>
        /// The scheme name
        /// </summary>
        public string Name { get; set; }
    }
}
