using UploadApi.Services.ImageUpload;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddScoped<IImageUpload, ImageUpload>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.UseCors(builder => builder.WithOrigins("http://localhost:4200", "https://tapar.info", "https://superadmin.tapar.info")
               .WithMethods("GET", "POST")
                .AllowAnyHeader()
                .AllowCredentials()
            );
app.MapControllers();

app.Run();
