using System.Collections.Generic;
using System.Threading.Tasks;
using amazen_server.Models;
using amazen_server.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_productService.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetOne()
        {
            try
            {
                return Ok(_productService.GetOne());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product newProduct)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newProduct.CreatorId = userInfo.Id;
                Product created = _productService.Create(newProduct);
                created.CreatorId = userInfo;
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}