using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsystentKonserwacji.Models;
using AsystentKonserwacji.Data;
using Microsoft.EntityFrameworkCore;

namespace AsystentKonserwacji.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MachinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachines()
        {
            return await _context.Machines.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Machine>> GetMachineById(int id)
        {
            var machine = await _context.Machines.FindAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            return machine;
        }

        [HttpPost]
        public async Task<ActionResult<Machine>> AddMachine(Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachineById", new { id = machine.Id }, machine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMachine(int id, Machine machine)
        {
            if (id != machine.Id)
            {
                return BadRequest();
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MachineExists(int id)
        {
            return _context.Machines.Any(e => e.Id == id);
        }
    }
}