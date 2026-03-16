#nullable enable annotations

using System.IO;
using System.Text;

namespace System.Web.UI
{
    public sealed class HtmlTextWriter : TextWriter
    {
        private readonly TextWriter _inner;

        public HtmlTextWriter(TextWriter writer)
        {
            _inner = writer;
        }

        public HtmlTextWriter(Stream stream) : this(new StreamWriter(stream)) { }
        public HtmlTextWriter(Stream stream, Encoding encoding) : this(new StreamWriter(stream, encoding)) { }

        public override Encoding Encoding => _inner.Encoding;

        public void WriteFullBeginTag(string tag) => _inner.Write($"<{tag}>");
        public void WriteEndTag(string tag) => _inner.Write($"</{tag}>");
        public void WriteBeginTag(string tag) => _inner.Write($"<{tag}");
        public void WriteAttribute(string name, string value)
        {
            _inner.Write($" {name}=\"{EncodeAttributeValue(value)}\"");
        }

        public override void Write(string? value) => _inner.Write(value ?? "");

        private static string EncodeAttributeValue(string value) =>
            value
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;");
    }
}
