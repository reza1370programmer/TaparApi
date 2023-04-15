
using AspNetCore.Totp;
using AspNetCore.Totp.Interface;
using Newtonsoft.Json;
using Serilog;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.core.Extensions;
using Tapar.Core.Common;
using Tapar.Core.Common.Middlewares;
using Tapar.Core.Contracts.Interfaces;


var builder = WebApplication.CreateBuilder(args);
var siteSettings = builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();

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
builder.Services.AddServicesOfAllTypes(typeof(IPlaceRepository).Assembly);
//builder.Services.AddScoped<ITotpGenerator, TotpGenerator>();
//builder.Services.AddScoped<ITotpValidator, TotpValidator>();
//builder.Services.AddElasticSearch(builder.Configuration);
builder.Services.AddJwtAuthentication(siteSettings.JwtSettings);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});
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
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
if (app.Environment.IsProduction())
{
    app.UseSpaStaticFiles();
}
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
});


app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(builder => builder.WithOrigins("http://localhost:4200", "https://tapar.info", "https://superadmin.tapar.info")
               .WithMethods("GET", "POST")
                .AllowAnyHeader()
                .AllowCredentials()
            );
app.Run();
