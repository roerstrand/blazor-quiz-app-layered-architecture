using Cyberquiz.BLL.Interfaces;
using Cyberquiz.BLL.Services;
using Cyberquiz.DAL.Data;
using Cyberquiz.DAL.Interface;
using Cyberquiz.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// ✅ FIX: CORS med AllowCredentials
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
                "https://localhost:7108",  // UI HTTPS
                "http://localhost:5108"    // UI HTTP (backup)
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // ✅ KRITISKT: Tillåt cookies!
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
    if (app.Environment.IsDevelopment())
    {
        // ⚠️ TA BORT EFTER TEST - Raderar allt vid varje start!
        await db.Database.EnsureDeletedAsync();
    }
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

app.MapControllers();

app.Run();
