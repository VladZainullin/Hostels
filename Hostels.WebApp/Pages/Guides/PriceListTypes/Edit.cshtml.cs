using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostels.WebApp.Pages.Guides.PriceListTypes;

[Authorize]
public class Edit : PageModel
{
    private readonly Repository<PriceListType, AppDbContext> _repository;

    public Edit(Repository<PriceListType, AppDbContext> repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public PriceListType? Entity { get; set; }
    
    public async Task<IActionResult> OnGet(int? id, CancellationToken cancellationToken)
    {
        if (id.HasValue)
        {
            Entity = await _repository.GetById(id.Value, cancellationToken);
        }
        else
        {
            Entity = new PriceListType();
        }
        if (Entity == null)
        {
            return RedirectToPage("../../NotFound");
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
    {
        if (Entity?.Id > 0)
        {
            _repository.UpdateAsync(Entity);
        }
        else
        {
            await _repository.AddAsync(Entity, cancellationToken);
        }            
        
        await _repository.SaveChangesAsync(cancellationToken);
        return RedirectToPage("./List");
    }
}