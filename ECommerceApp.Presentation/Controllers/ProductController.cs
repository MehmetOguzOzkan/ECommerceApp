using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceApp.Presentation.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 40)
        {
            return Ok(_productService.GetAllByPage(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_productService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDTO createProductDTO)
        {
            if (createProductDTO is null) return BadRequest();
            return Ok(_productService.Create(createProductDTO));
        }

        [HttpPut("{id}")]
        public  IActionResult Update(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO is null) return BadRequest();
            return Ok(_productService.Update(id, updateProductDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _productService.InActive(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string name, int? categoryId, double? minPrice, double? maxPrice)
        {
            return Ok(_productService.Search(name,categoryId,minPrice,maxPrice));
        }

        [HttpGet("sort/createddate")]
        public IActionResult OrderByCreatedDate([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_productService.OrderByCreatedDate(ids));
        }

        [HttpGet("sort/createddatedesc")]
        public IActionResult OrderByCreatedDateDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_productService.OrderByCreatedDateDescending(ids));
        }
        [HttpGet("sort/name")]
        public IActionResult OrderByName([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_productService.OrderByName(ids));
        }
        [HttpGet("sort/namedesc")]
        public IActionResult OrderByNameDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_productService.OrderByNameDescending(ids));
        }
        [HttpGet("sort/price")]
        public IActionResult OrderByPrice([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_productService.OrderByPrice(ids));
        }
        [HttpGet("sort/pricedesc")]
        public IActionResult OrderByPriceDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_productService.OrderByPriceDescending(ids));
        }
    }
}
