using Cyberquiz.Shared.DTOs.Auth;

namespace Cyberquiz.UI.Services;

public class AuthApiService
{
    private readonly HttpClient _http;

    public AuthApiService(HttpClient http) => _http = http;

    public async Task<(LoginResponseDto? Response, string? Error)> LoginAsync(string username, string password)
    {
        var res = await _http.PostAsJsonAsync("api/auth/login", new LoginRequestDto { Username = username, Password = password });
        if (res.IsSuccessStatusCode)
            return (await res.Content.ReadFromJsonAsync<LoginResponseDto>(), null);

        var body = await res.Content.ReadFromJsonAsync<ApiErrorDto>();
        return (null, body?.Message ?? "Inloggningen misslyckades.");
    }

    public async Task<(LoginResponseDto? Response, string? Error)> RegisterAsync(string username, string password)
    {
        var res = await _http.PostAsJsonAsync("api/auth/register", new RegisterRequestDto { Username = username, Password = password });
        if (res.IsSuccessStatusCode)
            return (await res.Content.ReadFromJsonAsync<LoginResponseDto>(), null);

        var body = await res.Content.ReadFromJsonAsync<RegisterErrorDto>();
        return (null, string.Join(", ", body?.Errors ?? []));
    }
}

file class ApiErrorDto
{
    public string? Message { get; set; }
}

file class RegisterErrorDto
{
    public string[] Errors { get; set; } = [];
}
