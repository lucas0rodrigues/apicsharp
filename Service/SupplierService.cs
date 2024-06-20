using apicsharp.Model.Supplier;
using apicsharp.ViewModel;

namespace apicsharp.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public SupplierModel Add(AddSupplierViewModel supplierViewModel)
        {
            return _supplierRepository.Save(new SupplierModel(supplierViewModel.Name));
        }

        public void Delete(string id)
        {
            SupplierModel supplier = this.Get(id) ?? throw new Exception("Fornecedor não encontrado");

            _supplierRepository.Delete(supplier);
        }

        public SupplierModel Get(string id)
        {
            if (id == null) { throw new Exception("Id da fornecedor não pode ser nulo"); }

            return _supplierRepository.Get(id);
        }

        public List<SupplierModel> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public SupplierModel Update(UpdateSupplierViewModel supplierViewModel)
        {
            SupplierModel supplier = this.Get(supplierViewModel.Id) ?? throw new Exception("Fornecedor não encontrado");

            supplier.Name = supplierViewModel.Name;

            return _supplierRepository.Update(supplier);
        }
    }
}
