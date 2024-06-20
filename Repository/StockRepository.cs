using apicsharp.Infra;
using apicsharp.Model.Stock;

namespace apicsharp.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly DatabaseContext _context;

        public StockRepository(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public StockModel Save(StockModel stock)
        {
            _context.Add(stock);
            _context.SaveChanges();

            return Get(stock.Id);
        }

        public void Delete(StockModel stock)
        {
            _context.Remove(stock);
            _context.SaveChanges();
        }

        public StockModel Get(string id) => _context.Stocks.Where(x => x.Id.Equals(id)).FirstOrDefault();

        public List<StockModel> GetAll()
        {
            return [.. _context.Stocks];
        }

        public StockModel Update(StockModel stock)
        {
            _context.Update(stock);
            _context.SaveChanges();

            return Get(stock.Id);
        }
    }
}
