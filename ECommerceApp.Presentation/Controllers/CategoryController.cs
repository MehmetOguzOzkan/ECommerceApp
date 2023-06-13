using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApp.Presentation.Controllers
{
    [Route("categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_categoryService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDTO createCategoryDTO)
        {
            if (createCategoryDTO is null) return BadRequest();
            return Ok(_categoryService.Create(createCategoryDTO));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            if (updateCategoryDTO is null) return BadRequest();
            return Ok(_categoryService.Update(id, updateCategoryDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _categoryService.InActive(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            return Ok(_categoryService.Search(name));
        }

        [HttpGet("sort/createddate")]
        public IActionResult OrderByCreatedDate([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_categoryService.OrderByCreatedDate(ids));
        }

        [HttpGet("sort/createddatedesc")]
        public IActionResult OrderByCreatedDateDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_categoryService.OrderByCreatedDateDescending(ids));
        }

        [HttpGet("sort/name")]
        public IActionResult OrderByName([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_categoryService.OrderByName(ids));
        }

        [HttpGet("sort/namedesc")]
        public IActionResult OrderByNameDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_categoryService.OrderByNameDescending(ids));
        }
    }
}
