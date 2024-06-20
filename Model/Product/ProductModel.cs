using apicsharp.Model.Category;
using apicsharp.Model.Stock;
using apicsharp.Model.Supplier;
using System.ComponentModel.DataAnnotations;

namespace apicsharp.Model.Product
{
    public class ProductModel
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string CategoryId { get; set; }

        public string SupplierId { get; set; }

        public string StockId { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(string name, double price, string categoryId, string supplierId, string stockId)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Price = price;
            CategoryId = categoryId;
            SupplierId = supplierId;
            StockId = stockId;
        }
    }
}
