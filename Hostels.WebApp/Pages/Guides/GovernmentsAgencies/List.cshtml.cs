using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.GovernmentsAgencies;

[Authorize]
public class List : PageModel
{
    private readonly AppDbContext _context;
    
    public List(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<GovernmentAgency> Entities { get; private set; } = new List<GovernmentAgency>();
    
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _context.Set<GovernmentAgency>()
            .Where(e => e.Title!.StartsWith(SearchTerm)
                        ||
                        string.IsNullOrEmpty(SearchTerm))
            .OrderBy(e => e.Title)
            .ToListAsync(cancellationToken);

        return Page();
    }
}