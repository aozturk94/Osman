using Microsoft.EntityFrameworkCore;
using Vatan.Business.Abstract;
using Vatan.Business.Concrete;
using Vatan.Data.Abstract;
using Vatan.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<VatanDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqLite")));

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();


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
