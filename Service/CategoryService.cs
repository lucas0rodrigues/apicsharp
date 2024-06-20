using apicsharp.Model.Category;
using apicsharp.ViewModel;

namespace apicsharp.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryModel Add(AddCategoryViewModel categoryViewModel)
        {
            return _categoryRepository.Save(new CategoryModel(categoryViewModel.Name));
        }

        public void Delete(string id)
        {
            CategoryModel category = this.Get(id) ?? throw new Exception("Categoria não encontrada");
            
            _categoryRepository.Delete(category);
        }

        public CategoryModel Get(string id)
        {
            if (id == null) { throw new Exception("Id da categoria não pode ser nulo"); }

            return _categoryRepository.Get(id);
        }

        public List<CategoryModel> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public CategoryModel Update(UpdateCategoryViewModel categoryViewModel)
        {
            CategoryModel category = this.Get(categoryViewModel.Id) ?? throw new Exception("Categoria não encontrada");

            category.Name = categoryViewModel.Name;

            return _categoryRepository.Update(category);
        }
    }
}
