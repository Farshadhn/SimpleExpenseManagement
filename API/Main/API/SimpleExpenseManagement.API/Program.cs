using Autofac;
using Autofac.Extensions.DependencyInjection;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Data;
using Lookif.Layers.Data.Repositories;
using Lookif.Layers.Service.Services.DataInitializer;
using Lookif.Layers.WebFramework.Configuration;
using Lookif.Layers.WebFramework.CustomMapping;
using Lookif.Layers.WebFramework.Middlewares;
using Lookif.Library.Common;
using SimpleExpenseManagement.Data;
using SimpleExpenseManagement.Data.Repositories;
using SimpleExpenseManagement.Data.Repositories.Interfaces;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);


ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;



// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Call ConfigureContainer on the Host sub property 
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    //RegisterType > As > Liftetime
    containerBuilder.RegisterType<SimpleExpenseManagementDBContext>().As<ApplicationDbContext>();

    containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
    containerBuilder.RegisterType<PersianCalendar>();

    containerBuilder.RegisterType<DataBaseService>().As<IDataBaseService>();
    containerBuilder.RegisterType<DataBaseRelatedService>().As<IDataBaseRelatedService>();
    var core = Assembly.Load("SimpleExpenseManagement.Core");
    var data = Assembly.Load("SimpleExpenseManagement.Data");
    var service = Assembly.Load("SimpleExpenseManagement.Service"); 
    containerBuilder.AddServices(core, data, service, typeof(Repository<>), typeof(Repository<,>));



});
builder.Services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));
SiteSettings _SiteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();

builder.Services.InitializeAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddDbContext<SimpleExpenseManagementDBContext>(configuration);
builder.Services.AddCustomIdentity<SimpleExpenseManagementDBContext>(_SiteSettings.IdentitySettings);
builder.Services.AddMinimalMvc();
builder.Services.AddJwtAuthentication(_SiteSettings.JwtSettings);
builder.Services.AddCustomApiVersioning();

builder.Services.AddCors(x => x.AddPolicy("default", y => y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

app.IntializeDatabase();
app.UseCustomExceptionHandler();
app.UseHsts(environment);
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCustomHeaders();

app.UseRouting();
app.UseCors("default");
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(config =>
{
    config.MapControllers();

    //  config.MapControllers();
   // config.MapFallbackToFile("index.html");
});



app.Run();
