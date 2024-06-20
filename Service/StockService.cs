using apicsharp.Model.Stock;
using apicsharp.ViewModel;

namespace apicsharp.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public StockModel Add(AddStockViewModel stockViewModel)
        {
            return _stockRepository.Save(new StockModel(stockViewModel.Name));
        }

        public void Delete(string id)
        {
            StockModel stock = this.Get(id) ?? throw new Exception("Estoque não encontrado");

            _stockRepository.Delete(stock);
        }

        public StockModel Get(string id)
        {
            if (id == null) { throw new Exception("Id do estoque não pode ser nulo"); }

            return _stockRepository.Get(id);
        }

        public List<StockModel> GetAll()
        {
            return _stockRepository.GetAll();
        }

        public StockModel Update(UpdateStockViewModel stockViewModel)
        {
            StockModel Stock = this.Get(stockViewModel.Id) ?? throw new Exception("Estoque não encontrado");

            Stock.Name = stockViewModel.Name;

            return _stockRepository.Update(Stock);
        }
    }
}
