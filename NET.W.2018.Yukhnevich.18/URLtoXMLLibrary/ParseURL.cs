using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using URLtoXMLLibrary.Parts;

namespace URLtoXMLLibrary
{
    /// <summary>
    /// Provides methods for parsing URL strings
    /// </summary>
    public class ParseUrl
    {
        /// <summary>
        /// Parses the URL string to new instance of UrlAddress class
        /// </summary>
        /// <param name="url">The URL string</param>
        /// <returns>The instance of URLAddress class</returns>
        public static UrlAddress ParseUrlAddress(string url)
        {
            string urlString = url.Trim();
            var regex = new Regex(@"^(?<scheme>\S+)://(?<host>\S+?)/((?<URLpath>\S+?)([?](?<parameters>\S+))?)?$");

            Match match = regex.Match(urlString);
            if (match.Success)
            {
                var urlAddress = new UrlAddress();
                urlAddress.Add(new Scheme(match.Groups["scheme"].Value));
                urlAddress.Add(new Host(match.Groups["host"].Value));
                if (match.Groups["URLpath"].Success)
                {
                    urlAddress.Add(ParseUrlPath(match.Groups["URLpath"].Value));
                    if (match.Groups["parameters"].Success)
                    {
                        urlAddress.Add(ParseParameters(match.Groups["parameters"].Value));
                    }
                }

                return urlAddress;
            }
            else
            {
                throw new ArgumentException("URL doesn't match to pattern");
            }
        }

        /// <summary>
        /// Parses the URL path to instance of UrlPath class
        /// </summary>
        /// <param name="pathString">The URL path string</param>
        /// <returns>The instance of UrlPath class</returns>
        private static UrlPath ParseUrlPath(string pathString)
        {
            string separator = "/";
            string[] parts = pathString.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            return new UrlPath(parts);
        }

        /// <summary>
        /// Parses the URL parameters string to instance of Parameters class
        /// </summary>
        /// <param name="paramString">The string of URL parameters</param>
        /// <returns>The instance of Parameters class</returns>
        private static Parameters ParseParameters(string paramString)
        {
            string paramSeparator = "&", keyValueSeparator = "=";
            string[] parts = paramString.Split(new string[] { paramSeparator }, StringSplitOptions.RemoveEmptyEntries);
            var parameters = new List<Parameter>();
            foreach (var param in parts)
            {
                string[] keyValue = param.Split(new string[] { keyValueSeparator }, StringSplitOptions.None);
                parameters.Add(new Parameter(keyValue[0], keyValue[1]));
            }

            return new Parameters(parameters);
        }
    }
}
