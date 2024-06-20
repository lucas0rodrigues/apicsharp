using apicsharp.Model.Category;
using apicsharp.Model.Product;
using apicsharp.Model.Stock;
using apicsharp.Model.Supplier;
using apicsharp.ViewModel;

namespace apicsharp.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IStockService _stockService;

        public ProductService(IProductRepository productRepository, ICategoryService categoryService, 
                              ISupplierService supplierService, IStockService stockService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _stockService = stockService;
        }

        public ProductDTO Add(AddProductViewModel productViewModel)
        {
            CategoryModel category = _categoryService.Add(productViewModel.Category);

            SupplierModel supplier = _supplierService.Add(productViewModel.Supplier);

            StockModel stock = _stockService.Add(productViewModel.Stock);

            ProductModel product = new(productViewModel.Name, productViewModel.Price, category.Id, supplier.Id, stock.Id);

            _productRepository.Save(product);

            return new ProductDTO(product.Id, product.Name, product.Price, category, supplier, stock);
        }

        public void Delete(string id)
        {
            ProductModel product = _productRepository.Get(id) ?? throw new Exception("Produto não encontrado");

            _productRepository.Delete(product);
        }

        public ProductDTO Get(string id)
        {
            ProductModel product = _productRepository.Get(id);

            CategoryModel category = _categoryService.Get(product.CategoryId);

            SupplierModel supplier = _supplierService.Get(product.SupplierId);

            StockModel stock = _stockService.Get(product.StockId);

            return new ProductDTO(product.Id, product.Name, product.Price, category, supplier, stock);
        }

        public List<ProductDTO> GetAll()
        {
            List<ProductModel> products = _productRepository.GetAll();

            List<ProductDTO> productDTOs = new List<ProductDTO>();

            products.ForEach(product =>
            {
                CategoryModel category = _categoryService.Get(product.CategoryId);

                SupplierModel supplier = _supplierService.Get(product.SupplierId);

                StockModel stock = _stockService.Get(product.StockId);

                productDTOs.Add(new ProductDTO(product.Id, product.Name, product.Price, category, supplier, stock));
            });

            return productDTOs;
        }

        public ProductDTO Update(UpdateProductViewModel productViewModel)
        {
            ProductModel product = _productRepository.Get(productViewModel.Id) ?? throw new Exception("Produto não encontrado");

            if (productViewModel.Name != null)
                product.Name = productViewModel.Name;
            
            if (productViewModel.Price != null)
                product.Price = productViewModel.Price.Value;
            
            if (productViewModel.Category is not null)
            {
                CategoryModel category = null;
                
                if (productViewModel.Category.Id is not null)
                    category = _categoryService.Get(productViewModel.Category.Id);

                if (category is null)
                    category = _categoryService.Add(productViewModel.Category);

                product.CategoryId = category.Id;
            }

            if (productViewModel.Supplier is not null)
            {
                SupplierModel supplier = null;

                if (productViewModel.Supplier.Id is not null)
                    supplier = _supplierService.Get(productViewModel.Supplier.Id);

                if (supplier is null)
                    supplier = _supplierService.Add(productViewModel.Supplier);

                product.SupplierId = supplier.Id;
            }

            if (productViewModel.Stock is not null)
            {
                StockModel stock = null;

                if (productViewModel.Stock.Id is not null)
                    stock = _stockService.Get(productViewModel.Stock.Id);

                if (stock is null)
                    stock = _stockService.Add(productViewModel.Stock);

                product.StockId = stock.Id;
            }

            _productRepository.Update(product);

            CategoryModel categoryModel = _categoryService.Get(product.CategoryId);

            SupplierModel supplierModel = _supplierService.Get(product.SupplierId);

            StockModel stockModel = _stockService.Get(product.StockId);

            return new ProductDTO(product.Id, product.Name, product.Price, categoryModel, supplierModel, stockModel);
        }
    }
}
