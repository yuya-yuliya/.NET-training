using System.Collections.Generic;

namespace No5.Solution
{
    public interface IConverter
    {
        string Convert(IEnumerable<DocumentPart> documentParts);
    }
}
