using apicsharp.Model.Product;
using apicsharp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace apicsharp.Controller
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel request)
        {
            if (request.Price == 0) { throw new Exception("Preço deve ser maior que zero"); }

            return Ok(_productService.Add(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateProductViewModel request)
        {
            return Ok(_productService.Update(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _productService.Delete(id);

            return NoContent();
        }
    }
}
