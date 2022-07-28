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
    public class TaikhoansController : ControllerBase
    {
        private readonly qlsachContext _context;

        public TaikhoansController(qlsachContext context)
        {
            _context = context;
        }

        // GET: api/Taikhoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taikhoan>>> GetTaikhoans()
        {
            return await _context.Taikhoans.ToListAsync();
        }

        // GET: api/Taikhoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taikhoan>> GetTaikhoan(string id)
        {
            var taikhoan = await _context.Taikhoans.FindAsync(id);

            if (taikhoan == null)
            {
                return NotFound();
            }

            return taikhoan;
        }

        // PUT: api/Taikhoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaikhoan(string id, Taikhoan taikhoan)
        {
            if (id != taikhoan.User)
            {
                return BadRequest();
            }

            _context.Entry(taikhoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaikhoanExists(id))
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

        // POST: api/Taikhoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taikhoan>> PostTaikhoan(Taikhoan taikhoan)
        {
            _context.Taikhoans.Add(taikhoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TaikhoanExists(taikhoan.User))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaikhoan", new { id = taikhoan.User }, taikhoan);
        }

        // DELETE: api/Taikhoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaikhoan(string id)
        {
            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            _context.Taikhoans.Remove(taikhoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaikhoanExists(string id)
        {
            return _context.Taikhoans.Any(e => e.User == id);
        }
    }
}
