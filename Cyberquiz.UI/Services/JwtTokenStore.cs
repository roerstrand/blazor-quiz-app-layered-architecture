namespace Cyberquiz.UI.Services;

public class JwtTokenStore
{
    public string? Token { get; private set; }
    public string? Username { get; private set; }

    public void Set(string token, string username)
    {
        Token = token;
        Username = username;
    }

    public void Clear()
    {
        Token = null;
        Username = null;
    }
}
