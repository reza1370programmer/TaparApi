using AspNetCore.ServiceRegistration.Dynamic;
using TaparApi.Common;
using TaparApi.Common.Extensions;
using TaparApi.Common.Services;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Contracts.Repositories;

var builder = WebApplication.CreateBuilder(args);
var siteSettings = builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
// Add services to the container.

builder.Services.AddControllers();
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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
