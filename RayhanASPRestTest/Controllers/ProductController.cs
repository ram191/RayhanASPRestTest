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
    public class ProductController : ControllerBase
    {
        private readonly OnlineOrderContext _context;

        public ProductController(OnlineOrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( new { Message = "Success retreiving data", Status = true, Data = _context.Products });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.Products.Where(x => x.Id == id).Select(x => x).SingleAsync();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Products.FindAsync(id);
            _context.Products.Remove(data);
            await _context.SaveChangesAsync();


            return StatusCode(204);
        }
        [HttpPost]
        public IActionResult Post(Product data)
        {
            _context.Products.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, Product data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
