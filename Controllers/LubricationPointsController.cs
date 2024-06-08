using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;
using Microsoft.EntityFrameworkCore;

namespace AsystentKonserwacji.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LubricationPointsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LubricationPointsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LubricationPoint>>> GetLubricationPoints()
        {
            return await _context.LubricationPoints.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LubricationPoint>> GetLubricationPointById(int id)
        {
            var lubricationPoint = await _context.LubricationPoints.FindAsync(id);

            if (lubricationPoint == null)
            {
                return NotFound();
            }

            return lubricationPoint;
        }

        [HttpPost]
        public async Task<ActionResult<LubricationPoint>> AddLubricationPoint(LubricationPoint lubricationPoint)
        {
            _context.LubricationPoints.Add(lubricationPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLubricationPointById", new { id = lubricationPoint.Id }, lubricationPoint);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLubricationPoint(int id, LubricationPoint lubricationPoint)
        {
            if (id != lubricationPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(lubricationPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LubricationPointExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLubricationPoint(int id)
        {
            var lubricationPoint = await _context.LubricationPoints.FindAsync(id);
            if (lubricationPoint == null)
            {
                return NotFound();
            }

            _context.LubricationPoints.Remove(lubricationPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LubricationPointExists(int id)
        {
            return _context.LubricationPoints.Any(e => e.Id == id);
        }
    }
}