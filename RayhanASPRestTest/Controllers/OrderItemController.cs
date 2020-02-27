using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RayhanASPRestTest.Models;
using Microsoft.EntityFrameworkCore;

namespace RayhanASPRestTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly OnlineOrderContext _context;

        public OrderItemController(OnlineOrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( new { Message = "Success retreiving data", Status = true, Data = _context.Order_items });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Order_items.Find(id);

            if (data == null)
            {
                return NotFound(new { Message = "Order item not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Order_items.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Order item not found", Status = false });
            }

            _context.Order_items.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(OrderItem data)
        {
            _context.Order_items.Add(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}
