using System.Data;
using System.Data.SqlClient;
using DS = F23L034_GestContact.Models.Dal.Services;
using DR = F23L034_GestContact.Models.Dal.Repositories;
using F23L034_GestContact.Models.Bll.Repositories;
using F23L034_GestContact.Models.Bll.Services;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("default")));
builder.Services.AddScoped<DR.IAuthRepository, DS.AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthService>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
