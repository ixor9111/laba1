using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laba1.Models;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksAPIController : ControllerBase
    {
        private readonly laba1Context _context;

        public WorksAPIController(laba1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetWork()
        {
            return await _context.Work.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWork(int id)
        {
            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }
            return work;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(int id, Work work)
        {
            if (id != work.WorkID)
            {
                return BadRequest();
            }

            _context.Entry(work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Work>> PostCategories(Work work)
        {
            if (work == null) return BadRequest();

            _context.Work.Add(work);
            await _context.SaveChangesAsync();
            return Ok(work);
            //return CreatedAtAction("GetCategories", new { id = categories.CategoriesId }, categories);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            var work = await _context.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            _context.Work.Remove(work);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkExists(int id)
        {
            return _context.Work.Any(e => e.WorkID == id);
        }
    }
}
