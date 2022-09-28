
using AspNetCore.Totp;
using AspNetCore.Totp.Interface;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json.Serialization;
using System.Text.Json;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.core.Extensions;
using Tapar.Core.Common;
using Tapar.Core.Common.Middlewares;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Core.Common.Dtos.Filters;

var webApplicationOptions =
    new WebApplicationOptions
    {
        EnvironmentName = Environments.Development,
        //EnvironmentName = Environments.Production,
    };

//var webApplicationOptions =
//    new WebApplicationOptions
//    {
//        EnvironmentName =
//            System.Diagnostics.Debugger.IsAttached ?
//                Environments.Development : Environments.Production,
//    };

//var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(webApplicationOptions);

var siteSettings = builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
// Add services to the container.

#region SerilogConfiguration

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

#endregion

builder.Services.AddControllers().AddNewtonsoftJson(q => q.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection(nameof(SiteSettings)));
builder.Services.AddDbContext(builder.Configuration);
//using package TanvirArjel.Extensions.Microsoft.DependencyInjection for inserting services dynamically
builder.Services.AddServicesOfAllTypes(typeof(ICat2Repsitory).Assembly);
builder.Services.AddScoped<ITotpGenerator, TotpGenerator>();
builder.Services.AddScoped<ITotpValidator, TotpValidator>();
builder.Services.AddJwtAuthentication(siteSettings.JwtSettings);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.Run();
