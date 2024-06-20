namespace apicsharp.Model.Stock
{
    public interface IStockRepository
    {
        StockModel Save(StockModel stock);

        List<StockModel> GetAll();

        StockModel Get(string id);

        StockModel Update(StockModel stock);

        void Delete(StockModel stock);
    }
}
