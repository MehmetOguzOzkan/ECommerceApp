using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApp.Presentation.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICartService _cartService;
        private readonly IAddressService _addressService;
        private readonly IOrderService _orderService;

        public UserController(IUserService userService, ICartService cartService, IAddressService addressService, IOrderService orderService)
        {
            _userService = userService;
            _cartService = cartService;
            _addressService = addressService;
            _orderService = orderService;
        }

        [HttpGet("{userId}/addresses")]
        public IActionResult GetAddressByUserId(int userId)
        {
            return Ok(_addressService.GetByUserId(userId));
        }

        [HttpGet("{userId}/orders")]
        public IActionResult GetOrdersByUserId(int userId)
        {
            return Ok(_orderService.GetByUserId(userId));
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 20)
        {
            return Ok(_userService.GetAllByPage(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDTO createUserDTO)
        {
            if (createUserDTO is null) return BadRequest();
            return Ok(_userService.Create(createUserDTO));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO is null) return BadRequest();
            return Ok(_userService.Update(id, updateUserDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _userService.InActive(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string name, int? roleId, string email)
        {
            return Ok(_userService.Search(name, roleId, email));
        }

        [HttpGet("sort/createddate")]
        public IActionResult OrderByCreatedDate([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_userService.OrderByCreatedDate(ids));
        }

        [HttpGet("sort/createddatedesc")]
        public IActionResult OrderByCreatedDateDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_userService.OrderByCreatedDateDescending(ids));
        }
        [HttpGet("sort/name")]
        public IActionResult OrderByName([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_userService.OrderByName(ids));
        }
        [HttpGet("sort/namedesc")]
        public IActionResult OrderByNameDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_userService.OrderByNameDescending(ids));
        }
    }
}
