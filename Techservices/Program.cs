using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Techservices;
using Techservices.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Techservices.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{

    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("techservices"));
    conn.Open();
    return conn;

});
// sql conections from azure 
builder.Services.AddDbContext<TechservicesContext>(options => 
    options.UseSqlServer(connectionString : "Server=tcp:techservices.database.windows.net,1433;Initial Catalog=Techservices;Persist Security Info=False;User ID=itsolutions;Password=Daniel1987@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TechservicesContext>();

// interfacerepository & class repository
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();

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
app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();// allow to show the razo pages of indentity 
app.Run();


app.Run();

