using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            return Ok(await _categoryService.GetAllCategoryAsync());
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            return Ok(await _categoryService.GetByIdCategoryAsync(id));
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori başarıyla eklendi");
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi");
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi");
        }
    }
}
