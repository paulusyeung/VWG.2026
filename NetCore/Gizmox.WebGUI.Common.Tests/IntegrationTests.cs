using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using System.Web;

namespace Gizmox.WebGUI.Common.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task HttpContextShim_PopulatedCorrectly_InMiddleware()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.ConfigureServices(services =>
                    {
                        services.AddDistributedMemoryCache();
                        services.AddSession();
                        services.AddMemoryCache();
                    });
                    webHost.Configure(app =>
                    {
                        app.UseSession();
                        
                        // Shim middleware
                        app.Use(async (context, next) =>
                        {
                            var cache = context.RequestServices.GetRequiredService<Microsoft.Extensions.Caching.Memory.IMemoryCache>();
                            HttpContextShim.Install(context, cache);
                            await next();
                        });

                        app.Run(async context =>
                        {
                            // Verify System.Web.HttpContext.Current
                            var legacyContext = System.Web.HttpContext.Current;
                            if (legacyContext == null)
                            {
                                context.Response.StatusCode = 500;
                                await context.Response.WriteAsync("HttpContext.Current is null");
                                return;
                            }

                            if (legacyContext.Request.HttpMethod != "GET")
                            {
                                context.Response.StatusCode = 500;
                                await context.Response.WriteAsync("HttpMethod mismatch");
                                return;
                            }

                            if (legacyContext.Session == null)
                            {
                                context.Response.StatusCode = 500;
                                await context.Response.WriteAsync("Session is null");
                                return;
                            }

                            await context.Response.WriteAsync("OK");
                        });
                    });
                });

            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("OK", content);
        }
    }
}
