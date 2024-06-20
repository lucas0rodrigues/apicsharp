using apicsharp.Model.Stock;
using apicsharp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace apicsharp.Controller
{
    [ApiController]
    [Route("/api/stock")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpPost]
        public IActionResult Add(AddStockViewModel request)
        {
            return Ok(_stockService.Add(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_stockService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_stockService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateStockViewModel request)
        {
            return Ok(_stockService.Update(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _stockService.Delete(id);

            return NoContent();
        }
    }
}
