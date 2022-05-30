using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostels.WebApp.Pages.Guides.ServiceTypes;

public class Edit : PageModel
{
    private readonly Repository<ServiceType, AppDbContext> _repository;

    public Edit(Repository<ServiceType, AppDbContext> repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public ServiceType? Entity { get; set; }
    
    public async Task<IActionResult> OnGet(int? id, CancellationToken cancellationToken)
    {
        if (id.HasValue)
        {
            Entity = await _repository.GetById(id.Value, cancellationToken);
        }
        else
        {
            Entity = new ServiceType();
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