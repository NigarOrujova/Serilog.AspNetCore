using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using SerilogLogging.Models.DataContexts;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();


Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
.ReadFrom.Configuration(configuration)
.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                 .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<SerilogDbContext>(cfg =>
{
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
