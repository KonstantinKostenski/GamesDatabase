using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Models;
using GameDatabase.Interfaces;
using System;

namespace GameDatabase.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly GameDatabaseDbContext _context;
        private readonly IDeveloperService _developerService;

        public DevelopersController(GameDatabaseDbContext context, IDeveloperService developerService)
        {
            _developerService = developerService;
            _context = context;
        }

        // GET: api/Developers
        [HttpGet]
        public async Task<IActionResult> GetDevelopers(int pageNumber, int pageSize)
        {
            try
            {
                throw new Exception();
                var model = await _developerService.GetAllDevelopers(pageNumber, pageSize);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloper([FromRoute] int id)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeveloper([FromRoute] int id, [FromBody] Developer developer)
        {
            try
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
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!DeveloperExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw ex;
                    }
                }

                return Ok(developer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Developers
        [HttpPost]
        public async Task<IActionResult> PostDeveloper([FromBody] Developer developer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Developers.Add(developer);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDeveloper", new { id = developer.Id }, developer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper([FromRoute] int id)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool DeveloperExists(int id)
        {
            return _context.Developers.Any(e => e.Id == id);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchObjectDevelopers searchObject)
        {
            try
            {
                var model = await _developerService.Search(searchObject);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}