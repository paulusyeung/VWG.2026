using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Linq;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Web;
using System.Web.SessionState;
using System.Web.Caching;

namespace Gizmox.WebGUI.Common.Tests
{
    public class ShimBehaviorTests
    {
        [Fact]
        public void SessionShim_StoreAndRetrieve_Works()
        {
            // Setup mock ISession
            var mockSession = new Mock<ISession>();
            var sessionData = new Dictionary<string, byte[]>();

            mockSession.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Callback<string, byte[]>((k, v) => sessionData[k] = v);
            
            mockSession.Setup(s => s.TryGetValue(It.IsAny<string>(), out It.Ref<byte[]>.IsAny))
                .Returns((string k, out byte[] v) => sessionData.TryGetValue(k, out v));

            mockSession.Setup(s => s.Keys).Returns(() => sessionData.Keys);

            // Create HttpSessionState and initialize with mock ISession
            var session = new HttpSessionState();
            session.Initialize(mockSession.Object);

            // Test simple string
            session["test_key"] = "test_value";
            Assert.Equal("test_value", session["test_key"]);
            
            // Verify it was stored as JSON in the mock session
            Assert.True(sessionData.ContainsKey("test_key"));
            var json = Encoding.UTF8.GetString(sessionData["test_key"]);
            Assert.Contains("test_value", json);

            // Test complex object
            var data = new { Name = "VWG", Version = 8 };
            session["complex"] = data;
            
            var retrieved = session["complex"] as JsonElement?;
            Assert.NotNull(retrieved);
            Assert.Equal("VWG", retrieved.Value.GetProperty("Name").GetString());
            Assert.Equal(8, retrieved.Value.GetProperty("Version").GetInt32());
        }

        [Fact]
        public void CacheShim_InsertAndGet_Works()
        {
            // Setup IMemoryCache
            var cacheOptions = new MemoryCacheOptions();
            var memoryCache = new MemoryCache(cacheOptions);

            // Initialize Cache shim
            System.Web.Caching.Cache.Initialize(memoryCache);
            var cache = HttpRuntime.Cache;

            // Test
            cache.Insert("c_key", "c_value");
            Assert.Equal("c_value", cache.Get("c_key"));

            // Verify it exists in IMemoryCache
            Assert.True(memoryCache.TryGetValue("c_key", out var val));
            Assert.Equal("c_value", val);
        }

        [Fact]
        public void SessionShim_CollectionManagement_Works()
        {
            var mockSession = new Mock<ISession>();
            var sessionData = new Dictionary<string, byte[]>();

            mockSession.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Callback<string, byte[]>((k, v) => sessionData[k] = v);
            mockSession.Setup(s => s.TryGetValue(It.IsAny<string>(), out It.Ref<byte[]>.IsAny))
                .Returns((string k, out byte[] v) => sessionData.TryGetValue(k, out v));
            mockSession.Setup(s => s.Remove(It.IsAny<string>()))
                .Callback<string>(k => sessionData.Remove(k));
            mockSession.Setup(s => s.Clear()).Callback(() => sessionData.Clear());
            mockSession.Setup(s => s.Keys).Returns(() => sessionData.Keys);

            var session = new HttpSessionState();
            session.Initialize(mockSession.Object);

            session["key1"] = "val1";
            session["key2"] = "val2";
            Assert.Equal(2, session.Count);
            Assert.Contains("key1", session.Keys.Cast<string>());
            Assert.Contains("key2", session.Keys.Cast<string>());

            session.Remove("key1");
            Assert.Equal(1, session.Count);
            Assert.Null(session["key1"]);

            session.Clear();
            Assert.Equal(0, session.Count);
        }

        [Fact]
        public void SessionShim_IntegerIndexing_Works()
        {
            var mockSession = new Mock<ISession>();
            var keys = new List<string> { "a", "b", "c" };
            
            mockSession.Setup(s => s.Keys).Returns(keys);
            mockSession.Setup(s => s.TryGetValue("a", out It.Ref<byte[]>.IsAny))
                .Returns((string k, out byte[] v) => { v = JsonSerializer.SerializeToUtf8Bytes("aval"); return true; });
            mockSession.Setup(s => s.TryGetValue("b", out It.Ref<byte[]>.IsAny))
                .Returns((string k, out byte[] v) => { v = JsonSerializer.SerializeToUtf8Bytes("bval"); return true; });

            var session = new HttpSessionState();
            session.Initialize(mockSession.Object);

            Assert.Equal("aval", session[0]);
            Assert.Equal("bval", session[1]);
        }

        [Fact]
        public void CacheShim_Remove_Works()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            System.Web.Caching.Cache.Initialize(memoryCache);
            var cache = HttpRuntime.Cache;

            cache.Insert("k", "v");
            Assert.Equal("v", cache.Get("k"));

            cache.Insert("k", null);
            Assert.Null(cache.Get("k"));
            Assert.False(memoryCache.TryGetValue("k", out _));
        }

        [Fact]
        public void CacheShim_FallbackToHashtable_Works()
        {
            // Note: Initialize is NOT called
            var cache = new System.Web.Caching.Cache();
            
            cache["key"] = "val";
            Assert.Equal("val", cache["key"]);
        }

        [Fact]
        public void HttpContextShim_FullWiring_Works()
        {
            var mockContext = new Mock<Microsoft.AspNetCore.Http.HttpContext>();
            var mockSession = new Mock<ISession>();
            var memoryCache = new MemoryCache(new MemoryCacheOptions());

            mockContext.Setup(c => c.Session).Returns(mockSession.Object);
            
            var mockFeatures = new Mock<Microsoft.AspNetCore.Http.Features.IFeatureCollection>();
            mockFeatures.Setup(f => f.Get<Microsoft.AspNetCore.Http.Features.ISessionFeature>())
                .Returns(new Mock<Microsoft.AspNetCore.Http.Features.ISessionFeature>().Object);
            mockContext.Setup(c => c.Features).Returns(mockFeatures.Object);

            HttpContextShim.Install(mockContext.Object, memoryCache);

            Assert.NotNull(System.Web.HttpContext.Current.Session);
            Assert.Same(HttpRuntime.Cache, System.Web.HttpContext.Current.Cache);

            System.Web.HttpContext.Current.Session["test"] = "session_ok";
            mockSession.Verify(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Once());
        }
    }
}
