using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository;
using HRMS.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using HRMS.Utility;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services DbContext
builder.Services.AddDbContext<HrmsAppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DbConnection")));

//options => options.SignIn.RequireConfirmedAccount = true
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
.AddEntityFrameworkStores<HrmsAppDbContext>().AddDefaultTokenProviders();

//Razor Page Access
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
}); 

builder.Services.AddRazorPages();
//Add Service for Reposiotory
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IEmailSender,EmailSender>();
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
app.UseAuthentication();
app.UseAuthorization();
//Mapping for razor Pages
app.MapRazorPages();

//this for Mapping Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

app.Run();
