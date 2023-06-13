using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApp.Presentation.Controllers
{
    [Authorize]
    [Route("carts")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cartService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCartDTO createCartDTO) 
        {
            if (createCartDTO is null) return BadRequest();
            return Ok(_cartService.Create(createCartDTO));
        }

        [HttpPost("items")]
        public IActionResult AddItem([FromBody]CreateCartItemDTO createCartItemDTO)
        {
            if (createCartItemDTO is null) return BadRequest();
            return Ok(_cartService.AddItem(createCartItemDTO));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCartDTO updateCartDTO)
        {
            if (updateCartDTO is null) return BadRequest();
            return Ok(_cartService.Update(id,updateCartDTO));
        }

        [HttpPut("items/{id}")]
        public IActionResult UpdateItem(int id, [FromBody]UpdateCartItemDTO updateCartItemDTO)
        {
            if (updateCartItemDTO is null) return BadRequest();
            return Ok(_cartService.UpdateItem(id, updateCartItemDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cartService.Delete(id);
            return Ok();
        }

        [HttpDelete("items/{id}")]
        public IActionResult DeleteItem(int id)
        {
            _cartService.DeleteItem(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _cartService.InActive(id);
            return Ok();
        }

        [HttpPatch("items/{id}")]
        public IActionResult InActiveItem(int id)
        {
            _cartService.InActiveItem(id);
            return Ok();
        }
    }
}
