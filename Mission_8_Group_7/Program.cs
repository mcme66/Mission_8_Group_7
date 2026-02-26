using Microsoft.EntityFrameworkCore;
using Mission_8_Group_7.Data;
using Mission_8_Group_7.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskConnection")));

builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Quadrants}/{id?}");

app.Run();