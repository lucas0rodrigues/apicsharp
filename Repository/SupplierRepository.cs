using apicsharp.Infra;
using apicsharp.Model.Supplier;

namespace apicsharp.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DatabaseContext _context;

        public SupplierRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public SupplierModel Save(SupplierModel supplier)
        {
            _context.Add(supplier);
            _context.SaveChanges();

            return Get(supplier.Id);
        }

        public void Delete(SupplierModel supplier)
        {
            _context.Remove(supplier);
            _context.SaveChanges();
        }

        public SupplierModel Get(string id) => _context.Suppliers.Where(x => x.Id.Equals(id)).FirstOrDefault();

        public List<SupplierModel> GetAll()
        {
            return [.. _context.Suppliers];
        }

        public SupplierModel Update(SupplierModel supplier)
        {
            _context.Update(supplier);
            _context.SaveChanges();

            return Get(supplier.Id);
        }
    }
}
