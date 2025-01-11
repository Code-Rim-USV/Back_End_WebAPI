using Back_End_WebAPI.Data;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connectionString);
//Initialize my DbContext inside the DI Container
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
    .AddCookie(options => 
    options.LoginPath = "/api/Auth/");


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    if (services.GetService<ApplicationDbContext>()!.Database.CanConnect())
    {
        Console.WriteLine("Can connect");
    }
    else
    {
        Console.WriteLine("Cannot connect");
    }



    SeedData.Initialize(services);
}

app.Use(async (context, next) =>
{
    var metadataIp = "169.254.169.254";
    if (context.Request.Host.Value.Contains(metadataIp) || context.Connection.RemoteIpAddress.ToString() == metadataIp)
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Access to metadata endpoint is forbidden");
        return;
    }
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
