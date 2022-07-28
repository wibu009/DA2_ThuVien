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
    public class DocgiumsController : ControllerBase
    {
        private readonly qlsachContext _context;

        public DocgiumsController(qlsachContext context)
        {
            _context = context;
        }

        // GET: api/Docgiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docgium>>> GetDocgia()
        {
            return await _context.Docgia.ToListAsync();
        }

        // GET: api/Docgiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Docgium>> GetDocgium(string id)
        {
            var docgium = await _context.Docgia.FindAsync(id);

            if (docgium == null)
            {
                return NotFound();
            }

            return docgium;
        }

        // PUT: api/Docgiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocgium(string id, Docgium docgium)
        {
            if (id != docgium.MaDg)
            {
                return BadRequest();
            }

            _context.Entry(docgium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocgiumExists(id))
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

        // POST: api/Docgiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Docgium>> PostDocgium(Docgium docgium)
        {
            _context.Docgia.Add(docgium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocgiumExists(docgium.MaDg))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocgium", new { id = docgium.MaDg }, docgium);
        }

        // DELETE: api/Docgiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocgium(string id)
        {
            var docgium = await _context.Docgia.FindAsync(id);
            if (docgium == null)
            {
                return NotFound();
            }

            _context.Docgia.Remove(docgium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocgiumExists(string id)
        {
            return _context.Docgia.Any(e => e.MaDg == id);
        }
    }
}
