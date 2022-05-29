using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostels.WebApp.Pages.Guides.Buildings;

public class List : PageModel
{
    private readonly Repository<Building, AppDbContext> _repository;
    
    public List(Repository<Building, AppDbContext> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Building> Entities { get; private set; } = new List<Building>();
    
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _repository.GetAll(cancellationToken);

        return Page();
    }
}