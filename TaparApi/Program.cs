using Microsoft.Extensions.DependencyInjection;
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
builder.Services.AddAutoMapper();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
builder.Services.AddScoped(typeof(IBusinessType1Repsitory), typeof(BusinessType1Repository));
builder.Services.AddScoped(typeof(IBusinessType2Repository), typeof(BusinessType2Repository));
builder.Services.AddScoped(typeof(IDynamicFieldsRepsitory), typeof(DynamicFieldsRepository));
builder.Services.AddScoped(typeof(IJwtService), typeof(JwtService));
builder.Services.AddJwtAuthentication(siteSettings.JwtSettings);
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.Run();
