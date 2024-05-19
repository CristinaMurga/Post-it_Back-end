using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Posti_it_web.Repository;
using Posti_it_web.Repository.Models;

namespace Posti_it_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostItsController : ControllerBase
    {
        private readonly PostItDbContext _context;

        public PostItsController(PostItDbContext context)
        {
            _context = context;
        }

        // GET: api/PostIts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostIt>>> GetPostIts()
        {
            return await _context.PostIts.ToListAsync();
        }

        // GET: api/PostIts/5
        [HttpGet("{username}")]
        public async Task<ActionResult<List<PostIt>>> GetPostIt(string username)
        {
            var postItList = await _context.PostIts
               .Where(p => p.Username == username)
               .ToListAsync();

            if (postItList == null || postItList.Count == 0)
            {
                return NotFound();
            }

            return Ok(postItList);
        }

        // PUT: api/PostIts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostIt(int? id, PostIt postIt)
        {
            if (id != postIt.Id)
            {
                return BadRequest();
            }

            _context.Entry(postIt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostItExists(id))
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

        // POST: api/PostIts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostIt>> PostPostIt(PostIt postIt)
        {
            try
            {
                postIt.Id = null;

                _context.PostIts.Add(postIt);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPostIt", new { id = postIt.Id }, postIt);
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }

        // DELETE: api/PostIts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostIt(int? id)
        {
            var postIt = await _context.PostIts.FindAsync(id);
            if (postIt == null)
            {
                return NotFound();
            }

            _context.PostIts.Remove(postIt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostItExists(int? id)
        {
            return _context.PostIts.Any(e => e.Id == id);
        }
    }
}
