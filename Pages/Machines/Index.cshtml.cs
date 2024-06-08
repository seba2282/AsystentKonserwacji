using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AsystentKonserwacji.Data;
using AsystentKonserwacji.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsystentKonserwacji.Pages.Machines
{
    public class MachineIndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MachineIndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Machine> Machines { get; set; }

        public async Task OnGetAsync()
        {
            Machines = await _context.Machines.ToListAsync();
        }
    }
}