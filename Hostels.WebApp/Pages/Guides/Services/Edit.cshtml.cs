using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.Services;

[Authorize]
public class Edit : PageModel
{
    private readonly Repository<Service, AppDbContext> _repository;
    private readonly AppDbContext _context;

    public Edit(Repository<Service, AppDbContext> repository, AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }
    
    public IEnumerable<SelectListItem> ServiceTypes { get; set; }

    [BindProperty]
    public Service? Entity { get; set; }
    
    public async Task<IActionResult> OnGet(int? id, CancellationToken cancellationToken)
    {
        ServiceTypes = await _context
            .Set<ServiceType>()
            .Select(e => new SelectListItem
            {
                Text = e.Title,
                Value = e.Id.ToString()
            })
            .ToListAsync(cancellationToken);
        if (id.HasValue)
        {
            Entity = await _repository.GetById(id.Value, cancellationToken);
        }
        else
        {
            Entity = new Service();
        }
        if (Entity == null)
        {
            return RedirectToPage("../../NotFound");
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            ServiceTypes = await _context
                .Set<ServiceType>()
                .Select(e => new SelectListItem
                {
                    Text = e.Title,
                    Value = e.Id.ToString()
                })
                .ToListAsync(cancellationToken);

            return Page();
        }
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