using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerceApp.Presentation.Controllers
{
    [Authorize]
    [Route("cards")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }


        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize = 40)
        {
            return Ok(_cardService.GetAllByPage(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cardService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCardDTO createCardDTO)
        {
            if (createCardDTO is null) return BadRequest();
            return Ok(_cardService.Create(createCardDTO));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCardDTO updateCardDTO)
        {
            if (updateCardDTO is null) return BadRequest();
            return Ok(_cardService.Update(id, updateCardDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cardService.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _cardService.InActive(id);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult Search(string number, int? userId)
        {
            return Ok(_cardService.Search(number, userId));
        }

        [HttpGet("sort/createddate")]
        public IActionResult OrderByCreatedDate([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_cardService.OrderByCreatedDate(ids));
        }

        [HttpGet("sort/createddatedesc")]
        public IActionResult OrderByCreatedDateDescending([FromBody] List<int> ids)
        {
            if (ids is null) return BadRequest();
            return Ok(_cardService.OrderByCreatedDateDescending(ids));
        }
    }
}
