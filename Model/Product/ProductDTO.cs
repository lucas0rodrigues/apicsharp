using apicsharp.Model.Category;
using apicsharp.Model.Stock;
using apicsharp.Model.Supplier;

namespace apicsharp.Model.Product
{
    public class ProductDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public CategoryModel Category { get; set; }

        public SupplierModel Supplier { get; set; }

        public StockModel Stock { get; set; }

        public ProductDTO(string id, string name, double price, CategoryModel category, SupplierModel supplier, StockModel stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Supplier = supplier;
            Stock = stock;
        }
    }
}
