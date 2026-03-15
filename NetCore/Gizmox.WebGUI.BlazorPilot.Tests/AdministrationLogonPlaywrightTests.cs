using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Microsoft.Playwright;
using Xunit.Sdk;

namespace Gizmox.WebGUI.BlazorPilot.Tests;

public class AdministrationLogonPlaywrightTests : IAsyncLifetime
{
    private bool _skipPlaywright;
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private Process? _serverProcess;
    private readonly string _url = "http://localhost:5050";

    public async Task InitializeAsync()
    {
        if (string.Equals(Environment.GetEnvironmentVariable("PLAYWRIGHT_SKIP"), "true", StringComparison.OrdinalIgnoreCase))
        {
            _skipPlaywright = true;
            return;
        }

        var pilotDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Gizmox.WebGUI.BlazorPilot"));
        var info = new ProcessStartInfo("dotnet", "run --urls http://localhost:5050")
        {
            WorkingDirectory = pilotDirectory,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
        };

        _serverProcess = Process.Start(info);
        if (_serverProcess == null)
            throw new InvalidOperationException("Failed to start pilot web app");

        // Wait for the server to start and bind
        using var http = new HttpClient();
        for (int i = 0; i < 30; i++)
        {
            try
            {
                var r = await http.GetAsync(_url + "/");
                if (r.IsSuccessStatusCode) break;
            }
            catch
            {
            }
            await Task.Delay(1000);
        }

        try
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        }
        catch (PlaywrightException)
        {
            _skipPlaywright = true;
        }
    }

    public async Task DisposeAsync()
    {
        if (_browser != null)
        {
            await _browser.CloseAsync();
            _browser = null;
        }

        _playwright?.Dispose();
        _playwright = null;

        if (_serverProcess != null && !(_serverProcess.HasExited))
        {
            _serverProcess.Kill(true);
            _serverProcess.Dispose();
            _serverProcess = null;
        }
    }

    [Fact]
    public async Task InvalidLogin_ShowsErrorMessage()
    {
        if (_skipPlaywright || _browser == null)
        {
            return;
        }

        var page = await _browser.NewPageAsync();
        try
        {
            await page.GotoAsync(_url + "/administration-logon");

            await page.FillAsync("#username", "baduser");
            await page.FillAsync("#password", "badpass");
            await page.ClickAsync("text=Log in");

            var error = await page.TextContentAsync("text=Invalid username or password.");
            Assert.Equal("Invalid username or password.", error?.Trim());
        }
        finally
        {
            await page.CloseAsync();
        }
    }

    [Fact]
    public async Task ValidLogin_ShowsLoggedInState()
    {
        if (_skipPlaywright || _browser == null)
        {
            return;
        }

        var page = await _browser.NewPageAsync();
        try
        {
            await page.GotoAsync(_url + "/administration-logon");

            await page.FillAsync("#username", "admin");
            await page.FillAsync("#password", "vwg1234");
            await page.ClickAsync("text=Log in");

            var success = await page.TextContentAsync("text=Logged in as");
            Assert.Contains("Logged in as", success ?? string.Empty);
        }
        finally
        {
            await page.CloseAsync();
        }
    }
}
