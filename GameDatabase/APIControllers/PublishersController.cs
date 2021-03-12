﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameDatabase.Data;
using GamesDatabaseBusinessLogic.Models;
using GameDatabase.Interfaces;

namespace GameDatabase.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly GameDatabaseDbContext _context;
        private readonly IPublisherService _publisherService;

        public PublishersController(GameDatabaseDbContext context, IPublisherService publisherService)
        {
            _context = context;
            _publisherService = publisherService;
        }

        // GET: api/Publishers
        [HttpGet]
        public async Task<IEnumerable<Publisher>> GetPublishers(int pageNumber, int pageSize)
        {
            var model = await _publisherService.GetAllPublishers(pageNumber, pageSize);
            return model;
        }

        // GET: api/Publishers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisher = await _context.Publishers.FindAsync(id);

            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        // PUT: api/Publishers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher([FromRoute] int id, [FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publisher.Id)
            {
                return BadRequest();
            }

            _context.Entry(publisher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
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

        // POST: api/Publishers
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublisher", new { id = publisher.Id }, publisher);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();

            return Ok(publisher);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search(SearchObjectPublishers searchObject)
        {
            var model = await _publisherService.Search(searchObject);
            return Ok(model);
        }

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }
    }
}