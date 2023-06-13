using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApp.Presentation.Controllers
{
    [Authorize]
    [Route("roles")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_roleService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRoleDTO createRoleDTO)
        {
            if (createRoleDTO is null) return BadRequest();
            return Ok(_roleService.Create(createRoleDTO));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateRoleDTO updateRoleDTO)
        {
            if (updateRoleDTO is null) return BadRequest();
            return Ok(_roleService.Update(id, updateRoleDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roleService.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _roleService.InActive(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            return Ok(_roleService.Search(name));
        }

        [HttpGet("sort/createddate")]
        public IActionResult OrderByCreatedDate([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_roleService.OrderByCreatedDate(ids));
        }

        [HttpGet("sort/createddatedesc")]
        public IActionResult OrderByCreatedDateDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_roleService.OrderByCreatedDateDescending(ids));
        }
        [HttpGet("sort/name")]
        public IActionResult OrderByName([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_roleService.OrderByName(ids));
        }
        [HttpGet("sort/namedesc")]
        public IActionResult OrderByNameDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_roleService.OrderByNameDescending(ids));
        }
    }
}
