using ApiServices.Contracts;
using ApiServices.Services;
using ApiServices.Services.MicroService;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.AutoMapper;
using NBAProject.Data;
using ProjectData.Data;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using Services.Contracts;
using Services.Services;
using Services.Services.CrudRelated;
using Services.Services.MicroService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IPrint, Print>();
// Api data services
builder.Services.AddScoped<IBasicFetcher, BasicFetcher>();
builder.Services.AddScoped<IBasicSeeder, BasicSeeder>();
builder.Services.AddScoped<IPlayerSeeder, PlayerSeeder>();
builder.Services.AddScoped<ITeamSeeder, TeamSeeder>();
builder.Services.AddScoped<IFetchPlayer, FetchPlayer>();
builder.Services.AddScoped<IGameSeeder, GameSeeder>();
builder.Services.AddScoped<IFetchGame, FetchGame>();
builder.Services.AddScoped<IStatSeeder, StatSeeder>();
builder.Services.AddScoped<IFetchStat, FetchStat>();
builder.Services.AddScoped<IFetchData, FetchData>();
//
builder.Services.AddScoped<IPlayerCrudOperations, PlayerCrudOperations>();
builder.Services.AddScoped<IChartDataService, ChartDataService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IStatService, StatService>();
builder.Services.AddScoped<IStatRepository, StatRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string role = "Manager";
    if (!(await roleManager.RoleExistsAsync(role)))
    {
        await roleManager.CreateAsync(new IdentityRole(role));
    }
}

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
