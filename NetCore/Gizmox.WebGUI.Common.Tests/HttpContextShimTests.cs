using System;
using Xunit;
using Microsoft.AspNetCore.Http;
using System.Web;  // shim namespace

namespace Gizmox.WebGUI.Common.Tests
{
    public class HttpContextShimTests
    {
        [Fact]
        public void Install_SetsCurrentAndCanRetrieveAspNetContext()
        {
            var context = new DefaultHttpContext();
            context.Request.Method = "POST";
            context.Request.ContentType = "application/json";
            context.Request.Headers["X-Test"] = "value";
            context.Request.QueryString = new QueryString("?foo=bar");
            // simulate a request cookie by setting the Cookie header; the framework will parse it into IRequestCookieCollection
            context.Request.Headers["Cookie"] = "cookie1=val";

            HttpContextShim.Install(context);

            Assert.NotNull(System.Web.HttpContext.Current);
            Assert.Equal("POST", System.Web.HttpContext.Current.Request.HttpMethod);
            Assert.Equal("application/json", System.Web.HttpContext.Current.Request.ContentType);
            Assert.Equal("value", System.Web.HttpContext.Current.Request.Headers["X-Test"]);
            Assert.Equal("bar", System.Web.HttpContext.Current.Request.QueryString["foo"]);
            Assert.Equal("val", System.Web.HttpContext.Current.Request.Cookies["cookie1"]?.Value);

            Assert.Same(context, HttpContextShim.ToAspNetCore());
        }
    }
}