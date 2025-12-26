using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Planimaq.Frontend.AuthenticationProviders;

public class AuthenticationProviderTest : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        //await Task.Delay(500);
        var anonimous = new ClaimsIdentity();
        var user = new ClaimsIdentity(authenticationType: "test");
        var admin = new ClaimsIdentity(
        [
            new("FirstName", "Juan"),
            new("LastName", "Zulu"),
            new(ClaimTypes.Name, "zulu@yopmail.com"),
            new(ClaimTypes.Role,"Admin")
        ],
        authenticationType: "test");

        //return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimous)));
        //return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(admin)));

    }
}
