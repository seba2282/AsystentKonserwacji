using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AsystentKonserwacji.Pages.LubricationPoints
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ApplicationDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public LubricationPoint LubricationPoint { get; set; }

        public IActionResult OnGet(int machineId)
        {
            LubricationPoint = new LubricationPoint
            {
                MachineId = machineId
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid.");
                return Page();
            }

            try
            {
                _context.LubricationPoints.Add(LubricationPoint);
                await _context.SaveChangesAsync();
                _logger.LogInformation("New lubrication point created with ID {LubricationPointId}", LubricationPoint.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the lubrication point.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the lubrication point.");
                return Page();
            }

            return RedirectToPage("/Machines/Details", new { id = LubricationPoint.MachineId });
        }
    }
}
