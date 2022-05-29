using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.Documents;

public class List : PageModel
{
    private readonly AppDbContext _context;
    
    public List(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Document> Entities { get; private set; } = new List<Document>();

    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _context.Documents
            .Include(d => d.GovernmentAgency)
            .ToListAsync(cancellationToken);

        return Page();
    }
}