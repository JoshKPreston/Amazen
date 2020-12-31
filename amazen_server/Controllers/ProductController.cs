using System.Collections.Generic;
using System.Threading.Tasks;
using amazen_server.Models;
using amazen_server.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<Product> GetOne(int id)
        {
            try
            {
                return Ok(_productService.GetOne(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> Create([FromBody] Product newProduct)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newProduct.CreatorId = userInfo.Id;
                Product created = _productService.Create(newProduct);
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpPut]
        // [Authorize]
        // public async Task<ActionResult<Product>> Edit([FromBody] Product data)
        // {
        //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //     return Ok(_productService.Edit(data, userInfo));
        // }

        // [HttpDelete]
        // [Authorize]
        // public async Task<ActionResult<Product>> Delete(int id)
        // {
        //     try
        //     {
        //         Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //         Product deleted = _productService.Delete(id, userInfo);
        //         return Ok(deleted);
        //     }
        //     catch (System.Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}