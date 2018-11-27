using System;
using System.Collections.Generic;

namespace No5.Solution.Converters
{
    public class ToHtmlConverter : IConverter
    {
        public virtual string Convert(IEnumerable<DocumentPart> documentParts)
        {
            string output = string.Empty;

            foreach (dynamic part in documentParts)
            {
                output += $"{this.HtmlPartConverter(part)}\n";
            }

            return output;
        }

        private string HtmlPartConverter(object part)
        {
            throw new NotImplementedException($"For type \"{part.GetType()}\" of document part not implemented convertion method");
        }

        private string HtmlPartConverter(BoldText part)
        {
            return "<b>" + part.Text + "</b>";
        }

        private string HtmlPartConverter(Hyperlink part)
        {
            return "<a href=\"" + part.Url + "\">" + part.Text + "</a>";
        }

        private string HtmlPartConverter(PlainText part)
        {
            return part.Text;
        }
    }
}
