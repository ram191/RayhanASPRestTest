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
    public class DriverController : ControllerBase
    {
        private readonly OnlineOrderContext _context;

        public DriverController(OnlineOrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( new { Message = "Success retreiving data", Status = true, Data = _context.Drivers });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Drivers.Find(id);

            if (data == null)
            {
                return NotFound(new { Message = "Driver not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Drivers.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Driver not found", Status = false });
            }

            _context.Drivers.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Driver data)
        {
            _context.Drivers.Add(data);
            _context.SaveChanges();
            return CreatedAtAction("created", new { Status = "Database has been updated", Data = ""});
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Driver data)
        {
            var query = _context.Drivers.First(x => x.Id == id);
            query.Full_name = data.Full_name;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
