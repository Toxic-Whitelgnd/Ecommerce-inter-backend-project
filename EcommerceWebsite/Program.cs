using EcommerceWebsite.Db;
using EcommerceWebsite.Repository.Abstraction;
using EcommerceWebsite.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod()
                .AllowAnyHeader();
            });
    }
    );


//for creating the user and connecting in the sql
builder.Services.AddDbContext<ApplicationUsercontext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//for product
builder.Services.AddDbContext<ApplicationProductContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//for product SIZE AS I FORGOTED ;[[
builder.Services.AddDbContext<ApplicationProductSizeContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//for Cartitems
builder.Services.AddDbContext<ApplicationCartContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

//for Orders
builder.Services.AddDbContext<ApplicationItemsOrderContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IFileService, FileService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//allowing all cors origin


app.UseCors();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Resources"
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
