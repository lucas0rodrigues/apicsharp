namespace apicsharp.Model.Product
{
    public interface IProductRepository
    {
        ProductModel Save(ProductModel product);

        List<ProductModel> GetAll();

        ProductModel Get(string id);

        ProductModel Update(ProductModel product);

        void Delete(ProductModel product);
    }
}
