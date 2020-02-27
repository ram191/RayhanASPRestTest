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
    [Route("api/v1/[controller]")]
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

            foreach(var x in data)
            {
                alldata.Add(new { x.User_id, x.Driver_id, status = Enum.GetName(typeof(Order_status), x.Status)});
            }
            return Ok( new { Message = "Success retreiving data", Status = true, Data = alldata });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _context.Orders.Where(x => x.Id == id).Select(x => x).SingleAsync();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Orders.FindAsync(id);
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

        [HttpPut]
        public IActionResult Put(int id, Order data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
