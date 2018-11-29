using System.Collections.Generic;

namespace URLtoXMLLibrary.Parts
{
    /// <summary>
    /// Represents the parameters in URL address
    /// </summary>
    public class Parameters : UrlPart
    {
        private List<Parameter> parameters;

        /// <summary>
        /// Initialize new instance of Parameters class with given enumerable of parameters
        /// </summary>
        /// <<param name="parameters">The enumeration of the parameters</param>
        public Parameters(IEnumerable<Parameter> parameters)
        {
            this.parameters = new List<Parameter>(parameters);
        }

        /// <summary>
        /// The list of parameters
        /// </summary>
        public List<Parameter> ParametersList
        {
            get
            {
                return new List<Parameter>(this.parameters);
            }
        }
    }
}
