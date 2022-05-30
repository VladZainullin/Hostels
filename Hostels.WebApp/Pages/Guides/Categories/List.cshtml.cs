using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.Categories;

[Authorize]
public class List : PageModel
{
    private readonly AppDbContext _context;
    
    public List(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> Entities { get; private set; } = new List<Category>();

    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _context.Сategories
            .Include(с => с.Building)
            .Include(с => с.HotelRoomType)
            .ToListAsync(cancellationToken);

        return Page();
    }
}