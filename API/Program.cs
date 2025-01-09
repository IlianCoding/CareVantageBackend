using CVB.DAL.Context;
using CVB.DAL.Initializer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CareVantageDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("CareVantageConnection")));

builder.Services.AddDbContext<KeycloakDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("KeycloakConnection")));
builder.Services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

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

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
    await databaseInitializer.InitializeAsync();
}
app.Run();