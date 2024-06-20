using apicsharp.Model.Supplier;
using apicsharp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace apicsharp.Controller
{
    [ApiController]
    [Route("/api/supplier")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        public IActionResult Add(AddSupplierViewModel request)
        {
            return Ok(_supplierService.Add(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_supplierService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_supplierService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateSupplierViewModel request)
        {
            return Ok(_supplierService.Update(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _supplierService.Delete(id);

            return NoContent();
        }
    }
}