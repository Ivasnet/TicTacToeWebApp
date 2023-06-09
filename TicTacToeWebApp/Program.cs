using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using TicTacToeWebApp.Controllers.Abstractions;
using TicTacToeWebApp.Controllers.Core;
using TicTacToeWebApp.Data;
using TicTacToeWebApp.Data.Models;
using TicTacToeWebApp.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<AppDbContext>(options =>
options.UseSqlite("DataSource=app.db"));

builder.Services.AddDefaultIdentity<AppUser>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbServices();

builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddSingleton<IGameController, GameController>();

builder.Services.AddSingleton<IGameWaiter, GameWaiter>();


builder.Services.AddSignalR();

//builder.WebHost.UseUrls("http://192.168.0.104:9876", "http://localhost:9876");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<GameHub>("/gameHub");
});

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();