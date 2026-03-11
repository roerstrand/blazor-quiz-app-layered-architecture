using Cyberquiz.UI.Data;
using Cyberquiz.UI.Components;
using Cyberquiz.UI.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cyberquiz.UI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AuthDbConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Auth-databas (Identity/användare) — hanteras enbart av UI
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Cyberquiz.UI")));

// Razor-komponenter
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Identity-tjänster
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
    })
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// ✅ FIX 3: HTTP-klient MED cookie support för API-anrop
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7237";
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    // ✅ KRITISKT: Skicka authentication cookies till API
    UseCookies = true,
    UseDefaultCredentials = true,
    // Tillåt cookies att skickas cross-domain
    CookieContainer = new System.Net.CookieContainer()
});

var app = builder.Build();

// Migrera och seed auth-databasen vid uppstart
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    await db.Database.MigrateAsync();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    await AuthSeeder.SeedAsync(userManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

// ✅ FIX 4: Rätt ordning är viktigt!
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Identity-endpoints (logout, external login osv.)
app.MapAdditionalIdentityEndpoints();

app.Run();
