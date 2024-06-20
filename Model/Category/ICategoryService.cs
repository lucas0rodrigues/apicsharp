using apicsharp.ViewModel;

namespace apicsharp.Model.Category
{
    public interface ICategoryService
    {
        CategoryModel Add(AddCategoryViewModel category);

        List<CategoryModel> GetAll();

        CategoryModel Get(string id);

        CategoryModel Update(UpdateCategoryViewModel category);

        void Delete(string id);
    }
}
