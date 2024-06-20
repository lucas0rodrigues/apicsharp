namespace apicsharp.Model.Supplier
{
    public interface ISupplierRepository
    {
        SupplierModel Save(SupplierModel supplier);

        List<SupplierModel> GetAll();

        SupplierModel Get(string id);

        SupplierModel Update(SupplierModel supplier);

        void Delete(SupplierModel supplier);
    }
}
