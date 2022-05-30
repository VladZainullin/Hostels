using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.HotelRooms;

public class List : PageModel
{
    private readonly AppDbContext _context;
    
    public List(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<HotelRoom> Entities { get; private set; } = new List<HotelRoom>();

    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _context.HotelRooms
            .Include(с => с.Category)
            .ToListAsync(cancellationToken);
        
        return Page();
    }
}