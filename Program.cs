using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//add razor run time compilation

//Context
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//add session
builder.Services.AddSession();

//climes
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("User", policy => policy.RequireClaim("User"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Login";
    });

    //Cokkie
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Login";
    });


var app = builder.Build();

//if error 404 or 500 redirect to error page
app.UseStatusCodePagesWithReExecute("/client/home/update");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

//Cokkie
app.UseCookiePolicy();


app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();





app.MapControllerRoute(
    name: "user",
    pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}");



app.MapAreaControllerRoute(
    name: "default",
    areaName: "Client",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapGet("/home/index", context =>
{
    context.Response.Redirect("/Client/home/index");
    return Task.CompletedTask;
});

app.Run();
