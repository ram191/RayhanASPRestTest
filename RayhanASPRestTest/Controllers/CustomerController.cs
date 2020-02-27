﻿using System;
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
    public class CustomerController : ControllerBase
    {
        private readonly OnlineOrderContext _context;

        public CustomerController(OnlineOrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<object> allData = new List<object>();
            var data = _context.Customers;
            foreach(var x in data)
            {
                allData.Add(new { x.Id, x.Full_name, x.Username, x.Email, x.Phone_number });
            } 
            return Ok( new { Message = "Success retreiving data", Status = true, Data = allData});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _context.Customers.Where(x => x.Id == id).Select(x => x).SingleAsync();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Customer data)
        {
            _context.Customers.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, Customer data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
