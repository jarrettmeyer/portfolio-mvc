using System.Text.RegularExpressions;
using System.Web;

namespace Portfolio.Lib
{
    public class HtmlTextFormatter
    {
        public IHtmlString FormatText(string text)
        {
            string html = "<p>" + text + "</p>";
            html = html.Replace("\r", "");
            html = new Regex("\n{2,}").Replace(html, "</p><p>");
            html = html.Replace("\n", "<br/>");
            return new HtmlString(html);
        }
    }
}