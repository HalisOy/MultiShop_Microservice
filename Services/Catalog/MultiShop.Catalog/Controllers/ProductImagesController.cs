using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController(IProductImageService _productImageService) : ControllerBase
    {
        [HttpGet("ProductImageList")]
        public async Task<IActionResult> ProductImageList()
        {
            return Ok(await _productImageService.GetAllProductImageAsync());
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            return Ok(await _productImageService.GetByIdProductImageAsync(id));
        }

        [HttpPost("CreateProductImage")]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün resmi başarıyla eklendi");
        }

        [HttpPost("UpdateProductImage")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün resmi başarıyla güncellendi");
        }

        [HttpDelete("DeleteProductImage")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resmi başarıyla silindi");
        }
    }
}
