using No5.Solution.Converters;

namespace No5.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document(new DocumentPart[] {
                new Hyperlink() { Text = "Hyper", Url = "someUrl.new" },
                new BoldText() { Text = "Bold" },
                new PlainText() { Text = "Plain" }
            });

            var htmlConverter = new ToHtmlConverter();
            var plainConverter = new ToPlainTextConverter();
            var latexConverter = new ToLaTeXConverter();

            System.Console.WriteLine($"Document to HTML:\n{document.ToHtml()}");
            System.Console.WriteLine($"Document to plain text:\n{document.ToPlainText()}");
            System.Console.WriteLine($"Document to LaTeX:\n{document.ToLaTeX()}");

            System.Console.ReadLine();
        }
    }
}
