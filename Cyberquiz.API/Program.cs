using Cyberquiz.BLL.AI_coach;
using Cyberquiz.BLL.Interfaces;
using Cyberquiz.BLL.Services;
using Cyberquiz.DAL.Data;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDbConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Endast quiz-databasen (kategorier, frågor, svar, progress)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// DAL
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProgressRepository, ProgressRepository>();

// BLL
builder.Services.AddScoped<IProgressService, ProgressService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAiCoachService, AiCoachService>();

// AI
builder.Services.AddHttpClient<IAiClient, AiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:11434/");
    client.Timeout = TimeSpan.FromMinutes(4);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7107",
                "http://localhost:5247"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
errorApp.Run(async context =>
{
context.Response.StatusCode = 500;
context.Response.ContentType = "application/json";

    await context.Response.WriteAsync("""
    {
        "message": "Internal server error"
    }
    """);
});
});

// Migrera och seed quiz-databasen vid uppstart
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //if (app.Environment.IsDevelopment())
    //{
    //    // ⚠️ TA BORT EFTER TEST - Raderar allt vid varje start!
    //    await db.Database.EnsureDeletedAsync();
    //}
    await db.Database.MigrateAsync();
    await DbSeeder.SeedAsync(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// ✅ CORS måste vara FÖRE MapControllers
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
