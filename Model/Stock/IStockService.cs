using apicsharp.Model.Category;
using apicsharp.ViewModel;

namespace apicsharp.Model.Stock
{
    public interface IStockService
    {
        StockModel Add(AddStockViewModel stock);

        List<StockModel> GetAll();

        StockModel Get(string id);

        StockModel Update(UpdateStockViewModel stock);

        void Delete(string id);
    }
}
