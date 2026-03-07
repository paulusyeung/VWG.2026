using System.IO;
using System.Linq;
using System.Text;

namespace System.Web
{
    public static class HttpUtility
    {
        public static string HtmlEncode(string? s) => s == null ? "" : System.Net.WebUtility.HtmlEncode(s);
        public static void HtmlEncode(string? s, TextWriter output) => output.Write(HtmlEncode(s));
        public static string HtmlDecode(string? s) => s == null ? "" : System.Net.WebUtility.HtmlDecode(s);
        public static void HtmlDecode(string? s, TextWriter output) => output.Write(HtmlDecode(s));
        public static string UrlEncode(string? s) => s == null ? "" : Uri.EscapeDataString(s).Replace("%20", "+");
        public static string UrlDecode(string? s) => s == null ? "" : Uri.UnescapeDataString(s.Replace("+", " "));
        public static string UrlPathEncode(string? s) => s == null ? "" : string.Join("/", s.Split('/').Select(Uri.EscapeDataString));
    }
}
