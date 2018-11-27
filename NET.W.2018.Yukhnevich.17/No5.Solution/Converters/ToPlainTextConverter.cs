using System;
using System.Collections.Generic;

namespace No5.Solution.Converters
{
    public class ToPlainTextConverter : IConverter
    {
        public virtual string Convert(IEnumerable<DocumentPart> documentParts)
        {
            string output = string.Empty;

            foreach (dynamic part in documentParts)
            {
                output += $"{PlainPartConverter(part)}\n";
            }

            return output;
        }

        private string PlainPartConverter(object part)
        {
            throw new NotImplementedException($"For type \"{part.GetType()}\" of document part not implemented convertion method");
        }

        private string PlainPartConverter(BoldText part)
        {
            return "**" + part.Text + "**";
        }

        private string PlainPartConverter(Hyperlink part)
        {
            return part.Text + " [" + part.Url + "]";
        }

        private string PlainPartConverter(PlainText part)
        {
            return part.Text;
        }
    }
}
