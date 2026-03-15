using Gizmox.WebGUI.BlazorPilot.Data;
using Microsoft.Extensions.Options;

namespace Gizmox.WebGUI.BlazorPilot.Tests;

public class AdministrationLogonServiceTests
{
    private AdministrationLogonService CreateService()
    {
        var options = Options.Create(new AdministrationOptions
        {
            LogonUserName = "admin",
            LogonPassword = "vwg1234",
            TokenLifetime = TimeSpan.FromMinutes(15)
        });

        return new AdministrationLogonService(options);
    }

    [Fact]
    public void ValidateCredentials_ReturnsTrue_OnCorrectCredentials()
    {
        var service = CreateService();

        Assert.True(service.ValidateCredentials("admin", "vwg1234"));
    }

    [Fact]
    public void ValidateCredentials_ReturnsFalse_OnIncorrectPassword()
    {
        var service = CreateService();

        Assert.False(service.ValidateCredentials("admin", "badpass"));
    }

    [Fact]
    public void Token_CanBeCreatedAndConsumed()
    {
        var service = CreateService();
        var token = service.CreateToken("admin", "vwg1234");

        Assert.True(service.TryGetToken(token, out var credentials));
        Assert.NotNull(credentials);
        Assert.Equal("admin", credentials!.Value.Username);
        Assert.Equal("vwg1234", credentials.Value.Password);
    }
}