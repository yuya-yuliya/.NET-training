namespace URLtoXMLLibrary.Parts
{
    /// <summary>
    /// Represents the host part in URL address
    /// </summary>
    public class Host : UrlPart
    {
        /// <summary>
        /// Initialize new instance of Host class with given hostname
        /// </summary>
        /// <param name="hostName">The name of host</param>
        public Host(string hostName)
        {
            this.Name = hostName;
        }
    
        /// <summary>
        /// The host name
        /// </summary>
        public string Name { get; set; }
    }
}
