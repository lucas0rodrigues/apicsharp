using apicsharp.Infra;
using apicsharp.Model.Category;
using apicsharp.Model.Product;
using apicsharp.Model.Stock;
using apicsharp.Model.Supplier;
using apicsharp.Repository;
using apicsharp.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string policyName = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<ISupplierService, SupplierService>()
    .AddScoped<ISupplierRepository, SupplierRepository>()
    .AddScoped<IStockService, StockService>()
    .AddScoped<IStockRepository, StockRepository>()
    .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("ApiCshap"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policyName);

app.MapControllers();

app.Run();