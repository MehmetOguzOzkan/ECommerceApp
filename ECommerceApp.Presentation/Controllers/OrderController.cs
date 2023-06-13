using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Presentation.Controllers
{
    [Authorize]
    [Route("orders")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 0, int pageSize=20)
        {
            return Ok(_orderService.GetAllByPage(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_orderService.GetById(id));
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDTO createOrderDTO)
        {
            if (createOrderDTO is null) return BadRequest();
            return Ok(_orderService.Create(createOrderDTO));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateOrderDTO updateOrderDTO)
        {
            if (updateOrderDTO is null) return BadRequest();
            return Ok(_orderService.Update(id, updateOrderDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult InActive(int id)
        {
            _orderService.InActive(id);
            return Ok();
        }
    }
}
