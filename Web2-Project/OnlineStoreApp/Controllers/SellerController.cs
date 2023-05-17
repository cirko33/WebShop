using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApp.DTOs;
using OnlineStoreApp.Exceptions;
using OnlineStoreApp.Interfaces.IServices;

namespace OnlineStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }


        [Authorize(Roles = "Seller")]
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int id))
                throw new BadRequestException("Bad ID. Logout and login.");

            var orders = await _sellerService.GetOrders(id);
            return Ok(new { orders = orders });
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("new-products")]
        public async Task<IActionResult> GetNewOrders()
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int id))
                throw new BadRequestException("Bad ID. Logout and login.");

            var orders = await _sellerService.GetNewOrders(id);
            return Ok(new { orders = orders });
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int id))
                throw new BadRequestException("Bad ID. Logout and login.");

            var products = await _sellerService.GetProducts(id);
            products.ForEach(x =>
            {
                x.ImageToImg = "data:image/png;base64" + Convert.ToBase64String(x.Image!);
                x.Image = null;
            });
            return Ok(new { products = products });
        }

        [Authorize(Roles = "Seller")]
        [HttpPost("products/image")]
        public async Task<IActionResult> UpdateImage(int id, IFormFile image)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new BadRequestException("Bad ID. Logout and login.");

            await _sellerService.AddImage(id, userId, image);
            return Ok();
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new BadRequestException("Bad ID. Logout and login.");

            var orders = await _sellerService.GetProduct(id, userId);
            return Ok(new { orders = orders });
        }

        [Authorize(Roles = "Seller")]
        [HttpPost("products")]
        public async Task<IActionResult> AddProduct(CreateProductDTO productDTO)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new BadRequestException("Bad ID. Logout and login.");

            await _sellerService.AddProduct(productDTO, userId);
            return Ok();
        }

        [Authorize(Roles = "Seller")]
        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new BadRequestException("Bad ID. Logout and login.");

            await _sellerService.UpdateProduct(productDTO.Id, productDTO, userId);
            return Ok();
        }

        [Authorize(Roles = "Seller")]
        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!int.TryParse(User.Claims.First(c => c.Type == "Id").Value, out int userId))
                throw new BadRequestException("Bad ID. Logout and login.");

            await _sellerService.DeleteProduct(id, userId);
            return Ok();
        }
    }
}
