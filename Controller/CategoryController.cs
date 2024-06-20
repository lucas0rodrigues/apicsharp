using apicsharp.Model.Category;
using apicsharp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace apicsharp.Controller
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel request)
        {
            return Ok(_categoryService.Add(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_categoryService.Get(id));
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryViewModel request)
        {
            return Ok(_categoryService.Update(request));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _categoryService.Delete(id);

            return NoContent();
        }
    }
}
