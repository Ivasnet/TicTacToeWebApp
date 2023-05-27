using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using TicTacToeWebApp.Data;
using TicTacToeWebApp.Data.Abstractions;
using TicTacToeWebApp.Data.Controllers;
using TicTacToeWebApp.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<AppDbContext>(options =>
options.UseSqlite("DataSource=app.db"));

builder.Services.AddDefaultIdentity<AppUser>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbServices();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddSingleton<WeatherForecastService>();

//builder.WebHost.UseUrls("http://192.168.0.104:9876", "http://localhost:9876");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
