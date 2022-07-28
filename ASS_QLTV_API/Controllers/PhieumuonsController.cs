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
    public class PhieumuonsController : ControllerBase
    {
        private readonly qlsachContext _context;

        public PhieumuonsController(qlsachContext context)
        {
            _context = context;
        }

        // GET: api/Phieumuons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phieumuon>>> GetPhieumuons()
        {
            return await _context.Phieumuons.ToListAsync();
        }

        // GET: api/Phieumuons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phieumuon>> GetPhieumuon(string id)
        {
            var phieumuon = await _context.Phieumuons.FindAsync(id);

            if (phieumuon == null)
            {
                return NotFound();
            }

            return phieumuon;
        }

        // PUT: api/Phieumuons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieumuon(string id, Phieumuon phieumuon)
        {
            if (id != phieumuon.MaPm)
            {
                return BadRequest();
            }

            _context.Entry(phieumuon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieumuonExists(id))
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

        // POST: api/Phieumuons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phieumuon>> PostPhieumuon(Phieumuon phieumuon)
        {
            _context.Phieumuons.Add(phieumuon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhieumuonExists(phieumuon.MaPm))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhieumuon", new { id = phieumuon.MaPm }, phieumuon);
        }

        // DELETE: api/Phieumuons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhieumuon(string id)
        {
            var phieumuon = await _context.Phieumuons.FindAsync(id);
            if (phieumuon == null)
            {
                return NotFound();
            }

            _context.Phieumuons.Remove(phieumuon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhieumuonExists(string id)
        {
            return _context.Phieumuons.Any(e => e.MaPm == id);
        }
    }
}
