using Cyberquiz.UI.Components;
using Cyberquiz.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Razor-komponenter
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Krävs av Blazors AuthorizeRouteView/AuthorizeView infrastruktur
// Cookie-scheme registreras som default så att IAuthenticationService.AuthenticateAsync(null) inte kastar
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddAuthorization();

// JWT-baserad autentisering (in-memory per circuit)
builder.Services.AddScoped<JwtTokenStore>();
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<JwtAuthStateProvider>());
builder.Services.AddCascadingAuthenticationState();

// Auth API-klient (login/register mot API)
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7237";
builder.Services.AddHttpClient<AuthApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

// HTTP-klient för anrop till API (quiz, frågor, progress)
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddHttpClient<AiCoachApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AiCoachApiBaseUrl"] ?? "https://localhost:7237");
    client.Timeout = TimeSpan.FromMinutes(5);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
