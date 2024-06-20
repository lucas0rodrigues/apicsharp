using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace apicsharp.Model.Stock
{
    public class StockModel
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public StockModel()
        {
        }

        public StockModel(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}
