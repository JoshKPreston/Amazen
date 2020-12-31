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
    [Route("api/wishlists")]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistService _wishlistService;

        public WishlistController(WishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Wishlist>>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_wishlistService.Get(userInfo));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Wishlist> GetOne(int id)
        {
            try
            {
                return Ok(_wishlistService.GetOne(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Wishlist>> Create([FromBody] Wishlist newWishlist)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newWishlist.CreatorId = userInfo.Id;
                Wishlist created = _wishlistService.Create(newWishlist);
                return Ok(created);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        // [HttpPut]
        // [Authorize]
        // public ActionResult<Product> Put(int id)
        // {
        //     try
        //     {
                
        //     }
        //     catch (System.Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            try
            {
                return Ok(_productService.Delete(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}