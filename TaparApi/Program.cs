using AspNetCore.ServiceRegistration.Dynamic;
using Newtonsoft.Json;
using TaparApi.Common;
using TaparApi.Common.Extensions;
using TaparApi.Common.Middlewares;

var webApplicationOptions =
    new WebApplicationOptions
    {
        //EnvironmentName = Environments.Development,
        EnvironmentName = Environments.Production,
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

builder.Services.AddControllers().AddNewtonsoftJson(q=>q.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection(nameof(SiteSettings)));
builder.Services.AddDbContext(builder.Configuration);
//using package AspNetCore.ServiceRegistration.Dynamic for inserting services dynamically by inheriting IScopedService
builder.Services.AddServicesOfType<IScopedService>();
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
