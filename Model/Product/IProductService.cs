using apicsharp.ViewModel;

namespace apicsharp.Model.Product
{
    public interface IProductService
    {
        ProductDTO Add(AddProductViewModel product);

        List<ProductDTO> GetAll();

        ProductDTO Get(string id);

        ProductDTO Update(UpdateProductViewModel product);

        void Delete(string product);
    }
}
