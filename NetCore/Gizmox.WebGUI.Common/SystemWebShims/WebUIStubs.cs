using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Web.Caching;

namespace System.Web.UI
{
    public interface ICallbackEventHandler
    {
        string GetCallbackResult();
        void RaiseCallbackEvent(string eventArgument);
    }

    public abstract class StateBag { }

    public abstract class PageStatePersister
    {
        protected PageStatePersister(Page page) { }
        public abstract void Load();
        public abstract void Save();
    }

    public class Page : Control
    {
        public virtual HttpRequest Request => null;
        public virtual HttpResponse Response => null;
        public virtual HttpServerUtility Server => null;
        public virtual System.Web.SessionState.HttpSessionState Session => null;
        public virtual Cache Cache => null;
        public virtual bool IsPostBack => false;
        public virtual bool IsCallback => false;
        public virtual string ClientID => null;
        public virtual StateBag ViewState => null;
        protected virtual PageStatePersister PageStatePersister => null;

        public virtual void Validate() { }
        public virtual void Validate(string validationGroup) { }
        protected virtual void OnInit(EventArgs e) { }
        protected virtual void OnPreLoad(EventArgs e) { }
        protected virtual void OnPreRender(EventArgs e) { }
        protected virtual void OnUnload(EventArgs e) { }
        public virtual Control FindControl(string id) => null;
        protected virtual NameValueCollection DeterminePostBackMode() => null;
        public virtual void AddAttributesToRender(HtmlTextWriter writer) { }
    }

    public class Control
    {
        public virtual string ID { get; set; }
        public virtual Control Parent { get; }
        public virtual bool Visible { get; set; }
        public virtual void Dispose() { }
    }
}

namespace System.Web.UI.WebControls
{
    public class WebControl : Control
    {
        protected virtual void AddAttributesToRender(HtmlTextWriter writer) { }
    }

    public class Style : Component { }

    public class HiddenField : WebControl
    {
        public virtual string Value { get; set; }
    }

    public class ToolboxDataAttribute : Attribute
    {
        public ToolboxDataAttribute(string data) { }
        public string Data { get; }
    }
}

namespace System.Web.UI.HtmlControls
{
    public abstract class HtmlControl : Control { }
    public class HtmlHead : HtmlControl { }
    public class HtmlForm : HtmlControl { }
}

namespace System.Web.Hosting
{
    public abstract class VirtualFile
    {
        protected VirtualFile(string virtualPath) { }
        public virtual string Name => null;
        public virtual string VirtualPath => null;
        public abstract Stream Open();
    }

    public abstract class VirtualPathProvider
    {
        public virtual string CombineVirtualPaths(string basePath, string relativePath) => null;
        public virtual bool FileExists(string virtualPath) => false;
        public virtual VirtualFile GetFile(string virtualPath) => null;
    }

    public class SimpleWorkerRequest : System.Web.HttpWorkerRequest
    {
        private string _filePath;
        private string _queryString;

        public SimpleWorkerRequest(string page, string query, TextWriter output) { _filePath = page; _queryString = query; }
        public SimpleWorkerRequest(string appVirtualDir, string appPhysicalDir, string page, string query, TextWriter output) { }

        public override string GetQueryString() => _queryString ?? string.Empty;
        public override string GetFilePath() => _filePath;
        public override string GetUriPath() => "/" + _filePath;
        public override string GetHttpVerbName() => "GET";
        public override string GetHttpVersion() => "HTTP/1.0";
        public override string GetLocalAddress() => "127.0.0.1";
        public override int GetLocalPort() => 80;
        public override string GetRemoteAddress() => "127.0.0.1";
        public override int GetRemotePort() => 0;
        public override string GetServerName() => "localhost";
        public virtual string GetKnownRequestHeader(int index) => null;
        public override string GetServerVariable(string name) => null;
        public override string GetFilePath(bool includePathTranslated) => _filePath;
        public override string GetAppPath() => "/";
        public override void SendStatus(int statusCode, string statusDescription) { }
        public override void SendKnownResponseHeader(int index, string value) { }
        public override void SendUnknownResponseHeader(string name, string value) { }
        public override void SendResponseFromMemory(byte[] data, int length) { }
        public override void SendResponseFromFile(string filename, long offset, long length) { }
        public override void SendResponseFromFile(IntPtr handle, long offset, long length) { }
        public override void FlushResponse(bool finalFlush) { }
        public override void EndOfRequest() { }
    }
}

namespace System.Web
{
    public abstract class HttpWorkerRequest
    {
        public abstract string GetQueryString();
        public abstract string GetFilePath();
        public abstract string GetUriPath();
        public abstract string GetHttpVerbName();
        public abstract string GetHttpVersion();
        public abstract string GetLocalAddress();
        public abstract int GetLocalPort();
        public abstract string GetRemoteAddress();
        public abstract int GetRemotePort();
        public virtual string GetServerName() => GetLocalAddress();
        public virtual string GetServerVariable(string name) => null;
        public virtual string GetFilePath(bool includePathTranslated) => GetFilePath();
        public virtual string GetAppPath() => "/";
        public abstract void SendStatus(int statusCode, string statusDescription);
        public abstract void SendKnownResponseHeader(int index, string value);
        public abstract void SendUnknownResponseHeader(string name, string value);
        public abstract void SendResponseFromMemory(byte[] data, int length);
        public abstract void SendResponseFromFile(string filename, long offset, long length);
        public abstract void SendResponseFromFile(IntPtr handle, long offset, long length);
        public abstract void FlushResponse(bool finalFlush);
        public abstract void EndOfRequest();
    }
}

namespace System.Web.Caching
{
    public class CacheDependency { }
}