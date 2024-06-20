namespace apicsharp.Model.Category
{
    public interface ICategoryRepository
    {
        CategoryModel Save(CategoryModel category);

        List<CategoryModel> GetAll();

        CategoryModel Get(string id);

        CategoryModel Update(CategoryModel category);

        void Delete(CategoryModel category);
    }
}
