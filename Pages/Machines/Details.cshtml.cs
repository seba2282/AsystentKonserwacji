using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;
using System.Threading.Tasks;

namespace AsystentKonserwacji.Pages.Machines
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Machine Machine { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Machine = await _context.Machines
                .Include(m => m.LubricationPoints)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Machine == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}