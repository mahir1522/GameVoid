using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PROG3050_Team_Project.Models;
using PROG3050_Team_Project.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IEmailSender, EmailSend>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GameVoidContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("GameVoidContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();
