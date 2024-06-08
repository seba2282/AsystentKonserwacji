using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;

public class EditMachineModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditMachineModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Machine? Machine { get; set; } // Nullable to avoid CS8601

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Machine = await _context.Machines.FindAsync(id);

        if (Machine == null)
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

        _context.Attach(Machine!).State = EntityState.Modified; // Use null-forgiving operator

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MachineExists(Machine!.Id)) // Use null-forgiving operator
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool MachineExists(int id)
    {
        return _context.Machines.Any(e => e.Id == id);
    }
}