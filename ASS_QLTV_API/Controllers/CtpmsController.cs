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
    public class CtpmsController : ControllerBase
    {
        private readonly qlsachContext _context;

        public CtpmsController(qlsachContext context)
        {
            _context = context;
        }

        // GET: api/Ctpms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ctpm>>> GetCtpms()
        {
            return await _context.Ctpms.ToListAsync();
        }

        // GET: api/Ctpms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ctpm>> GetCtpm(string id)
        {
            var ctpm = await _context.Ctpms.FindAsync(id);

            if (ctpm == null)
            {
                return NotFound();
            }

            return ctpm;
        }

        // PUT: api/Ctpms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtpm(string id, Ctpm ctpm)
        {
            if (id != ctpm.MaCtpm)
            {
                return BadRequest();
            }

            _context.Entry(ctpm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtpmExists(id))
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

        // POST: api/Ctpms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ctpm>> PostCtpm(Ctpm ctpm)
        {
            _context.Ctpms.Add(ctpm);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CtpmExists(ctpm.MaCtpm))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCtpm", new { id = ctpm.MaCtpm }, ctpm);
        }

        // DELETE: api/Ctpms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtpm(string id)
        {
            var ctpm = await _context.Ctpms.FindAsync(id);
            if (ctpm == null)
            {
                return NotFound();
            }

            _context.Ctpms.Remove(ctpm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtpmExists(string id)
        {
            return _context.Ctpms.Any(e => e.MaCtpm == id);
        }
    }
}
