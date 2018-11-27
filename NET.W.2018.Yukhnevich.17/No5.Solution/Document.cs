using No5.Solution.Converters;
using System;
using System.Collections.Generic;

namespace No5.Solution
{
    public class Document
    {
        private readonly List<DocumentPart> parts;

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public List<DocumentPart> DocumentParts => new List<DocumentPart>(parts);

        public string ToHtml()
        {
            return new ToHtmlConverter().Convert(this.parts);
        }

        public string ToPlainText()
        {
            return new ToPlainTextConverter().Convert(this.parts);
        }

        public string ToLaTeX()
        {
            return new ToLaTeXConverter().Convert(this.parts);
        }

        public string Convert(IConverter converter)
        {
            return converter.Convert(this.parts);
        }
    }
}
