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
    public class ColorsController : ControllerBase
    {
        private readonly PostItDbContext _context;

        public ColorsController(PostItDbContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColor()
        {
            return await _context.Color.ToListAsync();
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int? id)
        {
            var color = await _context.Color.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return color;
        }


        private bool ColorExists(int? id)
        {
            return _context.Color.Any(e => e.Id == id);
        }
    }
}
