using apicsharp.Infra;
using apicsharp.Model.Product;

namespace apicsharp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext ctx) 
        {
            _context = ctx;
        }

        public ProductModel Save(ProductModel product)
        {
            _context.Add(product);
            _context.SaveChanges();
            
            return Get(product.Id);
        }

        public void Delete(ProductModel product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public ProductModel Get(string id) => _context.Products.Where(x => x.Id.Equals(id)).FirstOrDefault();

        public List<ProductModel> GetAll()
        {
            return [.. _context.Products];
        }

        public ProductModel Update(ProductModel product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return Get(product.Id);
        }
    }
}
