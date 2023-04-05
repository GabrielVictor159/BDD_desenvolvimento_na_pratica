using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Service;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductService _productService = new ProductService();

       

        [HttpGet]
        public ActionResult<Product[]> Get([FromQuery] string? nome = "", [FromQuery] string? filtro = "", [FromQuery] string? sort = "", [FromQuery] int page = 1, [FromQuery] int size = 5)
        {

            return _productService.Get(nome, filtro, sort, page, size);

        }

    }
}
