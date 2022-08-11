using Flurl.Http.Configuration;
using FridgeProductsApp.MVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["X-Access-Token"];
    if (!string.IsNullOrEmpty(token))
        context.Request.Headers.Add("Authorization", "Bearer " + token);

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/");

app.Run();
