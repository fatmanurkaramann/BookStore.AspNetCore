using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract.Author;
using DataAccess.Abstract.Book;
using DataAccess.Abstract.Category;
using DataAccess.Concrete;
using DataAccess.Concrete.Author;
using DataAccess.Concrete.Book;
using DataAccess.Concrete.Category;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookAppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
    //appsettings.json dan "Sql" adlý bir baðlantý dizesini alýr.
    //Bu, veritabaný baðlantýsýnýn bilgilerini içeren bir dizedir.
});
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<BookAppDbContext>(); //, kullanýcý kimlik doðrulama iþlemleri
                                                   //için veritabaný baðlantýsýný ve yapýlandýrmasýný belirtir. 
builder.Services.AddScoped<IBookDal, BookDal>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorDal, AuthorDal>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "error",
    pattern: "/{*article}",
    defaults:new {controller="Home",action="Error"}

    );

app.Run();
