using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cyberquiz.UI.Services;

public class TokenProvider
{
    private readonly IConfiguration _config;
    private readonly AuthenticationStateProvider _authStateProvider;

    public TokenProvider(IConfiguration config, AuthenticationStateProvider authStateProvider)
    {
        _config = config;
        _authStateProvider = authStateProvider;
    }

    public async Task<string?> GetTokenAsync()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var userName = authState.User.Identity?.Name;
        if (string.IsNullOrEmpty(userName)) return null;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: [new Claim(ClaimTypes.Name, userName)],
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
