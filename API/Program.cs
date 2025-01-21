using CVB.BL.Domain;
using CVB.BL.Managers.ServicePck;
using CVB.BL.Utils.UnitOfWorkPck;
using CVB.DAL.Context;
using CVB.DAL.Initializer;
using CVB.DAL.Repository.AppointmentPck;
using CVB.DAL.Repository.PaymentPck;
using CVB.DAL.Repository.ServicePck;
using CVB.DAL.Repository.SubscriptionPck;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Loading in the Environment variables
DotNetEnv.Env.Load("../Infrastructure/.env");

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Connection strings 
var careVantageConnectionString = builder.Configuration.GetConnectionString("CareVantageConnection");
var keycloakConnectionString = builder.Configuration.GetConnectionString("KeycloakConnection");

static string ReplaceEnvironmentVariables(string input)
{
    return System.Text.RegularExpressions.Regex.Replace(input, @"\${([^}]+)}", match =>
    {
        var envVarName = match.Groups[1].Value;
        return Environment.GetEnvironmentVariable(envVarName) ?? match.Value;
    });
}

careVantageConnectionString = ReplaceEnvironmentVariables(careVantageConnectionString);
keycloakConnectionString = ReplaceEnvironmentVariables(keycloakConnectionString);

// Connection with both the databases
builder.Services.AddDbContext<CareVantageDbContext>(
    options => options.UseNpgsql(careVantageConnectionString));

builder.Services.AddDbContext<KeycloakDbContext>(
    options => options.UseNpgsql(keycloakConnectionString));

builder.Services.AddTransient<IDatabaseHealthCheck, DatabaseHealthCheck>();
builder.Services.AddScoped<DomainClassValidator>();

// Repositories
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

// Services
builder.Services.AddScoped<IUnitOfWorkCareVantage, UnitOfWorkCareVantage>();
builder.Services.AddScoped<IUnitOfWorkKeycloak, UnitOfWorkKeycloak>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var databaseInitializer = scope.ServiceProvider
        .GetRequiredService<IDatabaseHealthCheck>();
    await databaseInitializer.CheckDatabasesAsync();
    
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
        try
        {
            var careVantageDbContext = scope.ServiceProvider
                .GetRequiredService<CareVantageDbContext>();
            var keycloakDbContext = scope.ServiceProvider
                .GetRequiredService<KeycloakDbContext>();
            careVantageDbContext.Database.Migrate();
            keycloakDbContext.Database.Migrate();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while migrating the database in production: {e.Message}");
            throw;
        }
    }
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();