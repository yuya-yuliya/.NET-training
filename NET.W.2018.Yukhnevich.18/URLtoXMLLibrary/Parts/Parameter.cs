namespace URLtoXMLLibrary.Parts
{
    /// <summary>
    /// Represents the single parameter in URL address
    /// </summary>
    public class Parameter : UrlPart
    {
        /// <summary>
        /// Initialize new instance of Parameter class with given key and value
        /// </summary>
        /// <param name="paramKey">The parameter key</param>
        /// <param name="paramValue">The parameter value</param>
        public Parameter(string paramKey, string paramValue)
        {
            this.Key = paramKey;
            this.Value = paramValue;
        }

        /// <summary>
        /// The parameter key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The parameter value
        /// </summary>
        public string Value { get; set; }
    }
}
