using apicsharp.Model.Category;
using apicsharp.Model.Stock;
using apicsharp.Model.Supplier;

namespace apicsharp.ViewModel
{
    public class UpdateProductViewModel
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public double? Price { get; set; }

        public AddCategoryViewModel? Category { get; set; }

        public AddSupplierViewModel? Supplier { get; set; }

        public AddStockViewModel? Stock { get; set; }
    }
}
