using ApiServices.Contracts;
using ApiServices.Services;
using ApiServices.Services.MicroService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.AutoMapper;
using NBAProject.Data;
using Services.Contracts;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IPrint, Print>();
builder.Services.AddScoped<IBasicFetcher, BasicFetcher>();
builder.Services.AddScoped<IBasicSeeder, BasicSeeder>();
builder.Services.AddScoped<IPlayerSeeder, PlayerSeeder>();
builder.Services.AddScoped<ITeamSeeder, TeamSeeder>();
builder.Services.AddScoped<IFetchPlayer, FetchPlayer>();
builder.Services.AddScoped<IGameSeeder, GameSeeder>();
builder.Services.AddScoped<IFetchGame, FetchGame>();
builder.Services.AddScoped<IStatSeeder, StatSeeder>();
builder.Services.AddScoped<IFetchStat, FetchStat>();
builder.Services.AddScoped<IPlayerCrudOperations, PlayerCrudOperations>();
builder.Services.AddScoped<IFetchData, FetchData>();
builder.Services.AddAutoMapper(typeof(Program), typeof(MappingProfile));






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
