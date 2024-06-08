using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;

public class CreateMachineModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateMachineModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Machine Machine { get; set; } = new Machine(); // Initialize Machine to avoid null

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Machines.Add(Machine);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}