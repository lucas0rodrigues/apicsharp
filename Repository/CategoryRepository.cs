using apicsharp.Infra;
using apicsharp.Model.Category;
using apicsharp.Model.Product;

namespace apicsharp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public CategoryModel Save(CategoryModel category)
        {
            _context.Add(category);
            _context.SaveChanges();

            
            
            return Get(category.Id);
        }


        public void Delete(CategoryModel category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }

        public CategoryModel Get(string id) => _context.Categories.Where(x => x.Id.Equals(id)).FirstOrDefault();

        public List<CategoryModel> GetAll()
        {
            return [.. _context.Categories];
        }

        public CategoryModel Update(CategoryModel category)
        {
            _context.Update(category);
            _context.SaveChanges();

            return Get(category.Id);
        }
    }
}
