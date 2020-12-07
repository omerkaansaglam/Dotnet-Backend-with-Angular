using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using odevatasayar.Helpers;
using odevatasayar.Models;

namespace odevatasayar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizasyonController : ControllerBase
    {
        private readonly MainDbContext _context;

        public OrganizasyonController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Organizasyon
        [HttpGet]
        public IEnumerable<Organizasyon> GetOrganizasyon()
        {
            return _context.Organizasyon.Include(p=>p.Sirket);
        }

        // GET: api/Organizasyon/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizasyon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizasyon = await _context.Organizasyon.FindAsync(id);

            if (organizasyon == null)
            {
                return NotFound();
            }

            return Ok(organizasyon);
        }

        // PUT: api/Organizasyon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizasyon([FromRoute] int id, [FromBody] Organizasyon organizasyon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizasyon.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizasyon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizasyonExists(id))
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

        // POST: api/Organizasyon
        [HttpPost]
        public async Task<IActionResult> PostOrganizasyon([FromBody] Organizasyon organizasyon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Organizasyon.Add(organizasyon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizasyon", new { id = organizasyon.Id }, organizasyon);
        }

        // DELETE: api/Organizasyon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizasyon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organizasyon = await _context.Organizasyon.FindAsync(id);
            if (organizasyon == null)
            {
                return NotFound();
            }

            _context.Organizasyon.Remove(organizasyon);
            await _context.SaveChangesAsync();

            return Ok(organizasyon);
        }

        private bool OrganizasyonExists(int id)
        {
            return _context.Organizasyon.Any(e => e.Id == id);
        }
    }
}