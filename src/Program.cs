using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroupWebApp.Data;
using RunGroupWebApp.Models;
using RunGroupWebApp.RepoInterfaces;
using RunGroupWebApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var supportedCultures = new[] { "en", "pl", "ukr" };
builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");
builder.Services.AddMvc()
       .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
       .AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    opt.SetDefaultCulture(supportedCultures[0])
       .AddSupportedCultures(supportedCultures)
       .AddSupportedUICultures(supportedCultures);

});

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddIdentity<AppUser, IdentityRole>().
    AddEntityFrameworkStores<AppDBContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    //await Seed.SeedUsersAndRolesAsync(app);
    Seed.SeedData(app);
}

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
app.UseAuthentication();

var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
