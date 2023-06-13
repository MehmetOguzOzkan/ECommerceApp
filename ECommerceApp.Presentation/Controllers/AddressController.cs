using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApp.Presentation.Controllers
{
    [Authorize]
    [Route("addresses")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 40)
        {
            return Ok(_addressService.GetAllByPage(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_addressService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAddressDTO createAddressDTO)
        {
            if (createAddressDTO is null) return BadRequest();
            return Ok(_addressService.Create(createAddressDTO));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateAddressDTO updateAddressDTO)
        {
            if (updateAddressDTO is null) return BadRequest();
            return Ok(_addressService.Update(id, updateAddressDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _addressService.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _addressService.InActive(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string city, string district, string neighborhood, string street, string number, int? postalCode, int? userId)
        {
            return Ok(_addressService.Search(city, district, neighborhood, street, number, postalCode, userId));
        }

        [HttpGet("sort/createddate")]
        public IActionResult OrderByCreatedDate([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_addressService.OrderByCreatedDate(ids));
        }

        [HttpGet("sort/createddatedesc")]
        public IActionResult OrderByCreatedDateDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_addressService.OrderByCreatedDateDescending(ids));
        }

        [HttpGet("sort/address")]
        public IActionResult OrderByAddress([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_addressService.OrderByAddress(ids));
        }

        [HttpGet("sort/addressdesc")]
        public IActionResult OrderByAddressDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_addressService.OrderByAddressDescending(ids));
        }
    }
}
