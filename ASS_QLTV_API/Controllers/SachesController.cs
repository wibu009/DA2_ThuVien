using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASS_QLTV_API.Models;

namespace ASS_QLTV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachesController : ControllerBase
    {
        private readonly qlsachContext _context;

        public SachesController(qlsachContext context)
        {
            _context = context;
        }

        // GET: api/Saches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sach>>> GetSaches()
        {
            return await _context.Saches.ToListAsync();
        }

        // GET: api/Saches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sach>> GetSach(string id)
        {
            var sach = await _context.Saches.FindAsync(id);

            if (sach == null)
            {
                return NotFound();
            }

            return sach;
        }

        // PUT: api/Saches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSach(string id, Sach sach)
        {
            if (id != sach.MaSach)
            {
                return BadRequest();
            }

            _context.Entry(sach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SachExists(id))
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

        // POST: api/Saches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sach>> PostSach(Sach sach)
        {
            _context.Saches.Add(sach);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SachExists(sach.MaSach))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSach", new { id = sach.MaSach }, sach);
        }

        // DELETE: api/Saches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSach(string id)
        {
            var sach = await _context.Saches.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }

            _context.Saches.Remove(sach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SachExists(string id)
        {
            return _context.Saches.Any(e => e.MaSach == id);
        }
    }
}
