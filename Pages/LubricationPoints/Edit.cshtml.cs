using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;
using System.Threading.Tasks;

namespace AsystentKonserwacji.Pages.LubricationPoints
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LubricationPoint LubricationPoint { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            LubricationPoint = await _context.LubricationPoints.FindAsync(id);

            if (LubricationPoint == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LubricationPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LubricationPointExists(LubricationPoint.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Machines/Details", new { id = LubricationPoint.MachineId });
        }

        private bool LubricationPointExists(int id)
        {
            return _context.LubricationPoints.Any(e => e.Id == id);
        }
    }
}