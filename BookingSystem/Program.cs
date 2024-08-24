using BookingSystem.Data;
using BookingSystem.Models;
using BookingSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BookingSystemConnection") ?? throw new InvalidOperationException("Connection string 'TestAuthentication4ContextConnection' not found.");

builder.Services.AddDbContext<UserContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<UserModel, IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
    }
    )
    .AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Login");
    //other properties
});

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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "register",
    pattern: "Register",
    defaults: new { controller = "Register", action = "Register" }
);

app.MapControllerRoute(
    name: "dashboard",
    pattern: "Dashboard",
    defaults: new { controller = "Dashboard", action = "Dashboard" }
);

app.Run();
