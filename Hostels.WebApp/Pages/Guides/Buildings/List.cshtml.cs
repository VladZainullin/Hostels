using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.Buildings;

[Authorize]
public class List : PageModel
{
    private readonly AppDbContext _context;
    
    public List(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Building> Entities { get; private set; } = new List<Building>();
    
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _context.Set<Building>()
            .Where(e => e.Title!.StartsWith(SearchTerm)
                        ||
                        string.IsNullOrEmpty(SearchTerm))
            .OrderBy(e => e.Title)
            .ToListAsync(cancellationToken);

        return Page();
    }
}