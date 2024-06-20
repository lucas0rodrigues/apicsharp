using apicsharp.Model.Category;
using apicsharp.Model.Product;
using apicsharp.Model.Stock;
using apicsharp.Model.Supplier;
using Microsoft.EntityFrameworkCore;

namespace apicsharp.Infra
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<StockModel> Stocks { get; set; }

        public DbSet<SupplierModel> Suppliers { get; set; }
    }
}
