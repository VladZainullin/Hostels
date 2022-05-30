using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostels.WebApp.Pages.Guides.HotelRoomTypes;

[Authorize]
public class List : PageModel
{
    private readonly Repository<HotelRoomType, AppDbContext> _repository;
    
    public List(Repository<HotelRoomType, AppDbContext> repository)
    {
        _repository = repository;
    }

    public IEnumerable<HotelRoomType> Entities { get; private set; } = new List<HotelRoomType>();
    
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }
    
    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        Entities = await _repository.GetAll(cancellationToken);

        return Page();
    }
}