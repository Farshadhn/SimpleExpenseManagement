using Blazorise;
using Blazorise.Bootstrap;
using SimpleExpenseManagement.UI;
using SimpleExpenseManagement.UI.Authentication; 
using Lookif.UI.Component.Extension;
using Lookif.UI.Component.MiddleWares;
using Lookif.UI.Component.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); 
builder.Services.AddLookif();
builder.Services.AddLocalizer();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
var conf = builder.Configuration;
builder.Services.Configure<SiteSettings>(conf.GetSection(nameof(SiteSettings)));


var siteSettings = new SiteSettings();


builder.Configuration.Bind(nameof(SiteSettings), siteSettings);

builder.Services.AddScoped(sp => new HttpClient()
{
    BaseAddress = new Uri(siteSettings.Api)
});

builder.Services
          .AddBlazorise()
          .AddBootstrapProviders();


var app = builder.Build();

//ToDo put it in lookif - AddDefaultCulture is not working
CultureInfo culture;  
culture = PersianCulture.GetPersianCulture();
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
Thread.CurrentThread.CurrentUICulture = culture;




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
