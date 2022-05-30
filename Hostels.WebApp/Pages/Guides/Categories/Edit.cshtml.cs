using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.Categories;

[Authorize]
public class Edit : PageModel
{
    private readonly Repository<Category, AppDbContext> _repository;
    private readonly AppDbContext _context;

    public Edit(Repository<Category, AppDbContext> repository, AppDbContext context, IEnumerable<SelectListItem> hotelRoomTypes)
    {
        _repository = repository;
        _context = context;
        HotelRoomTypes = hotelRoomTypes;
    }

    public IEnumerable<SelectListItem> Buildings { get; set; }
    public IEnumerable<SelectListItem> HotelRoomTypes { get; set; }

    [BindProperty]
    public Category? Entity { get; set; }
    
    public async Task<IActionResult> OnGet(int? id, CancellationToken cancellationToken)
    {
        Buildings =  await _context.Buildings
            .Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.Id.ToString()
            })
            .ToListAsync(cancellationToken);
        HotelRoomTypes =  await _context.HostelRoomTypes
            .Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.Id.ToString()
            })
            .ToListAsync(cancellationToken);
        if (id.HasValue)
        {
            Entity = await _repository.GetById(id.Value, cancellationToken);
        }
        else
        {
            Entity = new Category();
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
            Buildings =  await _context.Buildings
                .Select(g => new SelectListItem
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                })
                .ToListAsync(cancellationToken);
            HotelRoomTypes =  await _context.HostelRoomTypes
                .Select(g => new SelectListItem
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                })
                .ToListAsync(cancellationToken);
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