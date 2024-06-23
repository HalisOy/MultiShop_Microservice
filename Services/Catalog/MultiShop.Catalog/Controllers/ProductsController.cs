using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService) : ControllerBase
    {
        [HttpGet("ProductList")]
        public async Task<IActionResult> ProductList()
        {
            return Ok(await _productService.GetAllProductAsync());
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            return Ok(await _productService.GetByIdProductAsync(id));
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi");
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi");
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi");
        }
    }
}
