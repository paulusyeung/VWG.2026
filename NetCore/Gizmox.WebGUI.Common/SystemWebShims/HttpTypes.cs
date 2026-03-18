// System.Web shims for .NET 8 migration - minimal stubs to enable compilation.
// Runtime implementations will be provided by ASP.NET Core adapters in the Server project.

#nullable enable annotations

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Web.SessionState;
using System.Security.Principal;
using System.Text;

// added for shim adapters
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace System.Web
{
    public enum HttpCacheability
    {
        NoCache,
        Private,
        Public,
        Server,
        ServerAndNoCache,
        ServerAndPrivate
    }

    public enum HttpCacheRevalidation
    {
        None,
        AllCaches,
        ProxyCaches
    }

    public interface IHttpHandler
    {
        void ProcessRequest(HttpContext context) { }
        bool IsReusable => false;
    }

    public interface IHttpAsyncHandler : IHttpHandler
    {
        IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object? extraData);
        void EndProcessRequest(IAsyncResult result);
    }

    public interface IHttpHandlerFactory
    {
        IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated);
        void ReleaseHandler(IHttpHandler handler);
    }

    public static class HttpRuntime
    {
        public static string? AppDomainAppPath { get; set; }
        public static string AppDomainAppVirtualPath { get; set; } = "/";
        public static string AppDomainAppId { get; set; } = "";
        public static string AppDomainId { get; set; } = "";
        public static string AspClientScriptPhysicalPath { get; set; } = "";
        public static string AspClientScriptVirtualPath { get; set; } = "/";
        public static string AspInstallDirectory { get; set; } = "";
        public static string BinDirectory { get; set; } = "";
        public static System.Web.Caching.Cache Cache { get; } = new System.Web.Caching.Cache();
        public static string ClrInstallDirectory { get; set; } = "";
        public static string CodegenDir { get; set; } = AppContext.BaseDirectory;
        public static bool IsOnUNCShare { get; set; }
        public static string MachineConfigurationDirectory { get; set; } = "";
    }

    public class HttpException : Exception
    {
        public int HttpCode { get; set; }
        public HttpException() { }
        public HttpException(string message) : base(message) { }
        public HttpException(string message, Exception? inner) : base(message, inner) { }
        public HttpException(int httpCode, string message) : base(message) { HttpCode = httpCode; }
        public HttpException(int httpCode, string message, Exception? inner) : base(message, inner) { HttpCode = httpCode; }

        public int GetHttpCode() => HttpCode <= 0 ? 500 : HttpCode;
    }

    public class HttpParseException : Exception
    {
        public string VirtualPath { get; }
        public int Line { get; }
        public HttpParseException(string message, Exception? inner, string virtualPath, string? sourceCode, int line)
            : base(message, inner)
        {
            VirtualPath = virtualPath;
            Line = line;
        }
    }

    public sealed class HttpContext
    {
        private static readonly AsyncLocal<HttpContext?> _current = new();

        public static HttpContext? Current
        {
            get => _current.Value;
            set => _current.Value = value;
        }

        public HttpRequest Request { get; set; } = null!;
        public HttpResponse Response { get; set; } = null!;
        public HttpServerUtility Server { get; set; } = null!;
        public HttpApplicationState Application { get; set; } = null!;
        public HttpSessionState Session { get; set; } = null!;
        public IDictionary Items { get; set; } = new Hashtable();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool IsCustomErrorEnabled { get; set; }
        public IPrincipal? User { get; set; }
        public System.Web.Caching.Cache Cache => HttpRuntime.Cache;
    }

    public sealed class HttpRequest
    {
        public HttpBrowserCapabilities Browser { get; set; } = new HttpBrowserCapabilities();
        public HttpFileCollection Files { get; set; } = new HttpFileCollection();
        public HttpCookieCollection Cookies { get; set; } = new HttpCookieCollection();
        public string ContentType { get; set; } = "";
        public int ContentLength { get; set; }
        public Encoding ContentEncoding { get; set; } = Encoding.UTF8;
        public Stream InputStream { get; set; } = Stream.Null;
        public string UserAgent { get; set; } = "";
        public string ApplicationPath { get; set; } = "/";
        public string PhysicalApplicationPath { get; set; } = "";
        public System.Collections.Specialized.NameValueCollection Headers { get; set; } = new System.Collections.Specialized.NameValueCollection();
        public string HttpMethod { get; set; } = "GET";
        public string? RawUrl { get; set; }
        public System.Collections.Specialized.NameValueCollection QueryString { get; set; } = new System.Collections.Specialized.NameValueCollection();
        public System.Collections.Specialized.NameValueCollection Form { get; set; } = new System.Collections.Specialized.NameValueCollection();
        public System.Collections.Specialized.NameValueCollection Params { get; set; } = new System.Collections.Specialized.NameValueCollection();
        public System.Collections.Specialized.NameValueCollection ServerVariables { get; set; } = new System.Collections.Specialized.NameValueCollection();
        public Uri? Url { get; set; }
        public string? UserHostAddress { get; set; }
        public string? this[string key] => Params[key];

        public void SaveAs(string filename) { }
        public void SaveAs(string filename, bool includeHeaders) { }
    }

    public sealed class HttpResponse
    {
        public string ContentType { get; set; } = "text/html";
        public int Expires { get; set; }
        public DateTime ExpiresAbsolute { get; set; }
        public Stream OutputStream { get; set; } = new MemoryStream();
        public string Status { get; set; } = "200 OK";
        public int StatusCode { get; set; } = 200;
        public string StatusDescription { get; set; } = "";
        public string CacheControl { get; set; } = "";
        public bool Buffer { get; set; } = true;
        public Encoding ContentEncoding { get; set; } = Encoding.UTF8;
        public Stream? Filter { get; set; }
        public TextWriter Output { get; set; } = new StreamWriter(new MemoryStream());
        public HttpCachePolicy Cache { get; set; } = new HttpCachePolicy();

        public HttpCookieCollection Cookies { get; set; } = new HttpCookieCollection();

        public void ClearHeaders() { }
        public void AppendHeader(string name, string value) { }
        public void AddHeader(string name, string value) { }
        public void Write(string s) => Output?.Write(s);
        public void Write(char[] buffer, int index, int count) => Output?.Write(buffer, index, count);
        public void Write(object obj) => Output?.Write(obj);
        public void BinaryWrite(byte[] buffer) { }
        public void Redirect(string url) { }
        public void WriteFile(string filename) { }
        public void Redirect(string url, bool endResponse) { }
        public void AddFileDependency(string filename) { }
        public void Flush() { }
        public void End() { }
        public void ClearContent() { }
        public void Close() { }
    }

    public sealed class HttpServerUtility
    {
        public string MachineName { get; set; } = Environment.MachineName;
        public string MapPath(string path) =>
            Path.Combine(AppContext.BaseDirectory, path.TrimStart('~', '/').Replace('/', Path.DirectorySeparatorChar));

        public string UrlEncode(string s) => global::System.Web.HttpUtility.UrlEncode(s);
        public string UrlDecode(string s) => global::System.Web.HttpUtility.UrlDecode(s);
        public string HtmlEncode(string s) => global::System.Web.HttpUtility.HtmlEncode(s);
        public string HtmlDecode(string s) => global::System.Web.HttpUtility.HtmlDecode(s);
    }

    public sealed class HttpApplicationState
    {
        private readonly Hashtable _items = new();

        public object? this[string name]
        {
            get => _items[name];
            set => _items[name] = value;
        }

        public string[] AllKeys => throw new NotImplementedException("HttpApplicationState.AllKeys");
        public object? this[int index] => throw new NotImplementedException("HttpApplicationState indexer");
        public int Count => _items.Count;

        public void Add(string name, object value) => _items[name] = value;
        public void Clear() => _items.Clear();
        public object? Get(int index) => throw new NotImplementedException();
        public object? Get(string name) => _items[name];
        public string? GetKey(int index) => throw new NotImplementedException();
        public void Lock() { }
        public void Remove(string name) => _items.Remove(name);
        public void RemoveAll() => _items.Clear();
        public void RemoveAt(int index) => throw new NotImplementedException();
        public void Set(string name, object value) => _items[name] = value;
        public void UnLock() { }
    }

    public sealed class HttpCookie
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public string Domain { get; set; } = "";
        public DateTime Expires { get; set; }
        public bool HasKeys => false;
        public bool HttpOnly { get; set; }
        public string Path { get; set; } = "/";
        public bool Secure { get; set; }
        public System.Collections.Specialized.NameValueCollection Values { get; set; } = new System.Collections.Specialized.NameValueCollection();
        
        public string? this[string key]
        {
            get => Values[key];
            set => Values[key] = value;
        }

        public HttpCookie(string name) => Name = name;
        public HttpCookie(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }

    public sealed class HttpCookieCollection : IEnumerable
    {
        private readonly List<HttpCookie> _cookies = new();

        public HttpCookie? this[string name] =>
            _cookies.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        
        public HttpCookie? this[int index] => index >= 0 && index < _cookies.Count ? _cookies[index] : null;

        public string[] AllKeys => _cookies.Select(c => c.Name).ToArray();
        
        public int Count => _cookies.Count;

        public void Add(HttpCookie cookie) => _cookies.Add(cookie);
        public void Set(HttpCookie cookie)
        {
            var idx = _cookies.FindIndex(c => string.Equals(c.Name, cookie.Name, StringComparison.OrdinalIgnoreCase));
            if (idx >= 0) _cookies[idx] = cookie;
            else _cookies.Add(cookie);
        }

        public void Add(string name) => _cookies.Add(new HttpCookie(name));
        public void Add(string name, string value) => _cookies.Add(new HttpCookie(name, value));

        public string? GetKey(int index) => index >= 0 && index < _cookies.Count ? _cookies[index].Name : null;
        public HttpCookie? Get(int index) => this[index];
        public HttpCookie? Get(string name) => this[name];
        
        public void Clear() => _cookies.Clear();
        public void Remove(string name) => _cookies.RemoveAll(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        public void CopyTo(Array dest, int index) => ((ICollection)_cookies).CopyTo(dest, index);

        public IEnumerator GetEnumerator() => _cookies.GetEnumerator();
    }

    public sealed class HttpPostedFile
    {
        public string FileName { get; set; } = "";
        public int ContentLength { get; set; }
        public string ContentType { get; set; } = "";
        public Stream InputStream { get; set; } = Stream.Null;
        
        public void SaveAs(string filename) { }
    }

    public sealed class HttpFileCollection : IEnumerable
    {
        private readonly List<HttpPostedFile> _files = new();
        private readonly Dictionary<string, HttpPostedFile> _byName = new(StringComparer.OrdinalIgnoreCase);

        public string[] AllKeys => _byName.Keys.ToArray();
        
        public System.Collections.Specialized.NameObjectCollectionBase.KeysCollection Keys
        {
            get
            {
                var nvc = new System.Collections.Specialized.NameValueCollection();
                foreach (var k in _byName.Keys) nvc.Add(k, "");
                return nvc.Keys;
            }
        }
        
        public HttpPostedFile? this[string name] => _byName.TryGetValue(name ?? "", out var f) ? f : _files.FirstOrDefault();
        public HttpPostedFile? this[int index] => index >= 0 && index < _files.Count ? _files[index] : null;
        public int Count => _files.Count;

        public void Add(string name, HttpPostedFile file)
        {
            _files.Add(file);
            _byName[name] = file;
        }
        public void Add(HttpPostedFile file) => _files.Add(file);
        public HttpPostedFile? Get(int index) => this[index];
        public HttpPostedFile? Get(string name) => this[name];
        public string? GetKey(int index) => index >= 0 && index < _files.Count ? _byName.Keys.ElementAtOrDefault(index) : null;

        public IEnumerator GetEnumerator() => _files.GetEnumerator();
    }

    public sealed class HttpCachePolicy
    {
        public void AppendCacheExtension(string extension) { }
        public void SetAllowResponseInBrowserHistory(bool allow) { }
        public void SetCacheability(HttpCacheability cacheability) { }
        public void SetCacheability(HttpCacheability cacheability, string field) { }
        public void SetRevalidation(HttpCacheRevalidation revalidation) { }
        public void SetLastModifiedFromFileDependencies() { }
        public void SetMaxAge(TimeSpan delta) { }
        public void SetNoServerCaching() { }
        public void SetNoStore() { }
        public void SetNoTransforms() { }
        public void SetOmitVaryStar(bool omit) { }
        public void SetProxyMaxAge(TimeSpan delta) { }
        public void SetSlidingExpiration(bool slide) { }
        public void SetValidUntilExpires(bool validUntilExpires) { }
        public void SetVaryByCustom(string custom) { }
        public void SetETag(string etag) { }
        public void SetETagFromFileDependencies() { }
        public void SetExpires(DateTime date) { }
        public void SetLastModified(DateTime date) { }
    }

    public sealed class HttpBrowserCapabilities
    {
        private readonly Dictionary<string, string> _capabilities = new();

        public string this[string key] => _capabilities.TryGetValue(key, out var v) ? v : "";
        public string Browser { get; set; } = "Default";
        public int MajorVersion { get; set; }
        public double MinorVersion { get; set; }
        public string Id => Browser;
    }

    /// <summary>
    /// Lightweight adapter that lets ASP.NET Core code install a real HttpContext
    /// so that legacy code using <see cref="System.Web.HttpContext.Current"/>
    /// can compile and, to a limited extent, function.
    /// </summary>
    public static class HttpContextShim
    {
        // backpointer to the AspNetCore context stored by middleware
        private static Microsoft.AspNetCore.Http.HttpContext? _asp;

        /// <summary>
        /// Installs the given ASP.NET Core context and creates a minimal shim.
        /// </summary>
        public static void Install(Microsoft.AspNetCore.Http.HttpContext asp, Microsoft.Extensions.Caching.Memory.IMemoryCache? cache = null)
        {
            _asp = asp;
            if (cache != null)
            {
                System.Web.Caching.Cache.Initialize(cache);
            }

            var sessionShim = new System.Web.SessionState.HttpSessionState();
            try
            {
                if (asp.Features.Get<Microsoft.AspNetCore.Http.Features.ISessionFeature>() != null)
                {
                    sessionShim.Initialize(asp.Session);
                }
            }
            catch { /* Session might not be configured */ }

            System.Web.HttpContext.Current = new HttpContext
            {
                Request = new HttpRequest
                {
                    ContentType = asp.Request?.ContentType ?? string.Empty,
                    HttpMethod = asp.Request?.Method ?? "GET",
                    Url = asp.Request != null ? TryCreateUri(asp.Request.GetDisplayUrl()) : null,
                    Headers = asp.Request != null ? ConvertHeaders(asp.Request.Headers) : new System.Collections.Specialized.NameValueCollection(),
                    QueryString = asp.Request != null ? ConvertCollection(asp.Request.Query) : new System.Collections.Specialized.NameValueCollection(),
                    Cookies = asp.Request != null ? ConvertCookies(asp.Request.Cookies) : new HttpCookieCollection()
                },
                Response = new HttpResponse
                {
                    ContentType = asp.Response?.ContentType ?? string.Empty
                },
                Server = new HttpServerUtility(),
                Application = new HttpApplicationState(),
                Session = sessionShim,
                Items = asp.Items != null ? ConvertItems(asp.Items) : new Hashtable()
            };
        }

        /// <summary>
        /// Retrieve the underlying ASP.NET Core context (if installed).
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext? ToAspNetCore() => _asp;

        private static System.Collections.Specialized.NameValueCollection ConvertHeaders(Microsoft.AspNetCore.Http.IHeaderDictionary headers)
        {
            var nvc = new System.Collections.Specialized.NameValueCollection();
            foreach (var kv in headers)
                nvc.Add(kv.Key, string.Join(",", kv.Value));
            return nvc;
        }

        private static System.Collections.Specialized.NameValueCollection ConvertCollection(Microsoft.AspNetCore.Http.IQueryCollection col)
        {
            var nvc = new System.Collections.Specialized.NameValueCollection();
            foreach (var kv in col)
                nvc.Add(kv.Key, string.Join(",", kv.Value));
            return nvc;
        }

        private static HttpCookieCollection ConvertCookies(Microsoft.AspNetCore.Http.IRequestCookieCollection cookies)
        {
            var cc = new HttpCookieCollection();
            foreach (var kv in cookies)
                cc.Add(kv.Key, kv.Value);
            return cc;
        }

        // helper to safely create a Uri or return null if invalid/empty
        private static Uri? TryCreateUri(string? uriString)
        {
            if (string.IsNullOrWhiteSpace(uriString))
                return null;
            if (Uri.TryCreate(uriString, UriKind.Absolute, out var result))
                return result;
            return null;
        }

        private static IDictionary ConvertItems(IDictionary<object, object?> items)
        {
            // ASP.NET Core's HttpContext.Items is IDictionary<object, object?>; convert to non-generic IDictionary
            var ht = new Hashtable();
            foreach (var kv in items)
            {
                ht[kv.Key] = kv.Value;
            }
            return ht;
        }
    }
}
