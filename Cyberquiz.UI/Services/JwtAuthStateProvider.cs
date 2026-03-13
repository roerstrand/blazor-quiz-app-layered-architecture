using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cyberquiz.UI.Services;

public class JwtAuthStateProvider : AuthenticationStateProvider
{
    private readonly JwtTokenStore _tokenStore;
    private static readonly AuthenticationState Anonymous =
        new(new ClaimsPrincipal(new ClaimsIdentity()));

    public JwtAuthStateProvider(JwtTokenStore tokenStore)
    {
        _tokenStore = tokenStore;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (string.IsNullOrEmpty(_tokenStore.Token))
            return Task.FromResult(Anonymous);

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(_tokenStore.Token);
        var identity = new ClaimsIdentity(jwt.Claims, "jwt");
        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }

    public void NotifyAuthStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
