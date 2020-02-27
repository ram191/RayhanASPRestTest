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
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.Drivers.Where(x => x.Id == id).Select(x => x).SingleAsync();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(data);
            await _context.SaveChangesAsync();


            return StatusCode(204);
        }
        [HttpPost]
        public IActionResult Post(Driver data)
        {
            _context.Drivers.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, Driver data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
