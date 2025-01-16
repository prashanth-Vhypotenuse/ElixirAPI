using ElixirAPI.Data;
using ElixirAPI.Repository;
using ElixirAPI.Handler;
using Serilog;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File("logs/Log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

try {
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Add services to the container.
    // Add CORS services
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("RestrictedCorsPolicy", policy =>
        {
            policy.WithOrigins("http://localhost", "http://localhost:3000") // Allow specific origins
                  .AllowAnyHeader() // Allow specific headers or use `.WithHeaders("Content-Type", "Authorization")`
                  .AllowAnyMethod(); // Allow specific methods or use `.WithMethods("GET", "POST")`
        });
    });

    builder.Services.AddSingleton<DatabaseContext>();
    builder.Services.AddScoped<ContentRepository>();
    builder.Services.AddScoped<MenuRepository>();
    builder.Services.AddScoped<ContentTypeRepository>();
    builder.Services.AddScoped<MenuHandler>();
    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(); // Add Swagger services

    var app = builder.Build();

    Log.Information("App build successfully");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger(); // Enable Swagger middleware
        app.UseSwaggerUI(); // Enable Swagger UI
    }

    app.UseHttpsRedirection();

    app.MapStaticAssets();

    app.UseCors("RestrictedCorsPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex) {
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally {
    Log.CloseAndFlush();
}
