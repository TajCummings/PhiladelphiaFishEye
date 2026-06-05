using Classes;
using System;
using System.IO;

// 1. Logic from your copy-paste
Console.WriteLine("Starting the application..."); 
// Note: ReadLine will pause the web server startup until you press Enter in the terminal
var nameTest = Console.ReadLine(); 

var account = new Guess("Taj", "5/25/2026");
Console.WriteLine($"User {account.UserName} was created with Guess {account.GuessDate}");

// 2. Web Application Setup
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();