using System.Diagnostics;
using NUnit.Framework;

namespace Portfolio.Lib
{
    [TestFixture]
    public class HtmlTextFormatterTests
    {
        [Test]
        [TestCase(null, Result = "<p></p>")]
        [TestCase("", Result = "<p></p>")]
        [TestCase("Hello, World!", Result = "<p>Hello, World!</p>")]
        [TestCase("Line 1\nLine 2", Result = "<p>Line 1<br/>Line 2</p>")]
        [TestCase("Line 1\r\nLine 2", Result = "<p>Line 1<br/>Line 2</p>")]
        [TestCase("Paragraph 1\n\nParagraph 2", Result = "<p>Paragraph 1</p><p>Paragraph 2</p>")]
        [TestCase("Paragraph 1\r\n\r\nParagraph 2", Result = "<p>Paragraph 1</p><p>Paragraph 2</p>")]
        public string FormatText_returns_expected_result(string inString)
        {
            var result = new HtmlTextFormatter().FormatText(inString);
            var htmlString = result.ToHtmlString();
            Debug.WriteLine("Input: {0}, Output: {1}", inString ?? "<null>", htmlString);
            return htmlString;
        }
    }
}
