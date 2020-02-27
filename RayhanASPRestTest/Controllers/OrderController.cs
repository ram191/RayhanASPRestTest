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
    public class OrderController : ControllerBase
    {
        private readonly OnlineOrderContext _context;

        public OrderController(OnlineOrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alldata = new List<object>();
            var data = _context.Orders;
            var orderData = _context.Order_items;

            foreach(var x in data)
            {
                alldata.Add(new { x.Id, x.User_id, x.Driver_id, status = Enum.GetName(typeof(Order_status), x.Status)});
            }
            return Ok( new { Message = "Success retreiving data", Status = true, Data = alldata });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Orders.Find(id);

            if (data == null)
            {
                return NotFound(new { Message = "Order not found", Status = false });
            }

            var alldata = new { data.Id, data.User_id, data.Driver_id, status = Enum.GetName(typeof(Order_status), data.Status) };
            return Ok(new { Message = "Success retreiving data", Status = true, Data = alldata });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Orders.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            _context.Orders.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Order data)
        {
            _context.Orders.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Order data)
        {
            var query = _context.Orders.First(x => x.Id == id);
            query.Status = data.Status;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
