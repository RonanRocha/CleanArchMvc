using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}", Name ="GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)  return NotFound();

            return Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest();

            var category = await _categoryService.AddAsync(categoryDTO);

            return new CreatedAtActionResult("Get", "Categories", new { id = category.Id }, category);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if(id != categoryDTO.Id) return BadRequest();

            if (categoryDTO == null) return BadRequest();

            await _categoryService.UpdateAsync(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if(category == null) return NotFound();

            await _categoryService.RemoveAsync(id);

            return Ok(category);
        }

    }
}
