using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostels.WebApp.Pages.Guides.PriceListTypes;

[Authorize]
public class List : PageModel
{
    private readonly Repository<PriceListType, AppDbContext> _repository;
    
    public List(Repository<PriceListType, AppDbContext> repository)
    {
        _repository = repository;
    }

    public IEnumerable<PriceListType> Entities { get; private set; } = new List<PriceListType>();
    
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _repository.GetAll(cancellationToken);

        return Page();
    }
}