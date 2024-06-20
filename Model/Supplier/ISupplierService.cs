using apicsharp.ViewModel;

namespace apicsharp.Model.Supplier
{
    public interface ISupplierService
    {
        SupplierModel Add(AddSupplierViewModel supplier);

        List<SupplierModel> GetAll();

        SupplierModel Get(string id);

        SupplierModel Update(UpdateSupplierViewModel supplier);

        void Delete(string id);
    }
}
