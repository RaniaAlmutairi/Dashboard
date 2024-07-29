using DashboardProject.Data;
using Microsoft.EntityFrameworkCore;
using DashboardProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(

    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    }


    );
builder.Services.AddDbContext<ApplicationDbContext>(

    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    }

    );
builder.Services.AddDbContext<UserContext>(

    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    }


    );
builder.Services.AddDefaultIdentity<DashboardProjectUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UserContext>();
builder.Services.AddRazorPages();
builder.Services.AddSession();
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

app.UseHttpsRedirection();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();





