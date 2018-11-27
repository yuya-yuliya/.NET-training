using System;
using System.Collections.Generic;

namespace No5.Solution.Converters
{
    public class ToLaTeXConverter : IConverter
    {
        public virtual string Convert(IEnumerable<DocumentPart> documentParts)
        {
            string output = string.Empty;

            foreach (dynamic part in documentParts)
            {
                output += $"{LaTeXPartConverter(part)}\n";
            }

            return output;
        }

        private string LaTeXPartConverter(object part)
        {
            throw new NotImplementedException($"For type \"{part.GetType()}\" of document part not implemented convertion method");
        }

        private string LaTeXPartConverter(BoldText part)
        {
            return "\\textbf{" + part.Text + "}";
        }

        private string LaTeXPartConverter(Hyperlink part)
        {
            return "\\href{" + part.Url + "}{" + part.Text + "}";
        }

        private string LaTeXPartConverter(PlainText part)
        {
            return part.Text;
        }
    }
}
