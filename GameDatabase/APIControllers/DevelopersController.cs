using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Models;

namespace GameDatabase.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly GameDatabaseDbContext _context;

        public DevelopersController(GameDatabaseDbContext context)
        {
            _context = context;
        }

        // GET: api/Developers
        [HttpGet]
        public IEnumerable<Developer> GetDevelopers()
        {
            return _context.Developers;
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developer = await _context.Developers.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeveloper([FromRoute] int id, [FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != developer.Id)
            {
                return BadRequest();
            }

            _context.Entry(developer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
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

        // POST: api/Developers
        [HttpPost]
        public async Task<IActionResult> PostDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeveloper", new { id = developer.Id }, developer);
        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            _context.Developers.Remove(developer);
            await _context.SaveChangesAsync();

            return Ok(developer);
        }

        private bool DeveloperExists(int id)
        {
            return _context.Developers.Any(e => e.Id == id);
        }
    }
}