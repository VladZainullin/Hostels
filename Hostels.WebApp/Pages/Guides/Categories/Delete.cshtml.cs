using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostels.WebApp.Pages.Guides.Categories;

[Authorize]
public class Delete : PageModel
{
    private readonly Repository<Category, AppDbContext> _repository;

    public Delete(Repository<Category, AppDbContext> repository)
    {
        _repository = repository;
    }

    public Category? Entity { get; set; }
    
    public async Task<IActionResult> OnGet(int id, CancellationToken cancellationToken)
    {
        Entity = await _repository.GetById(id, cancellationToken);
        if (Entity == null)
        {
            return RedirectToPage("../../../NotFound");
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPost(int id, CancellationToken cancellationToken)
    {
        var entity = await _repository.RemoveAsync(id, cancellationToken);
        if (entity == null)
        {
            return RedirectToPage("../../../NotFound");
        }
        
        await _repository.SaveChangesAsync(cancellationToken);
        
        return RedirectToPage("./List");
    }
}