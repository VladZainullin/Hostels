using Hostels.Core.Entities;
using Hostels.Core.Enums;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hostels.WebApp.Pages.Guides.HotelRooms;

public class Edit : PageModel
{
    private readonly Repository<HotelRoom, AppDbContext> _repository;
    private readonly AppDbContext _context;
    private readonly IHtmlHelper _htmlHelper;

    public Edit(Repository<HotelRoom, AppDbContext> repository, AppDbContext context, IHtmlHelper htmlHelper)
    {
        _repository = repository;
        _context = context;
        _htmlHelper = htmlHelper;
    }
    
    public IEnumerable<SelectListItem> Categories { get; set; }
    
    public IEnumerable<SelectListItem> Statuses { get; set; }

    [BindProperty]
    public HotelRoom? Entity { get; set; }
    
    public async Task<IActionResult> OnGet(int? id, CancellationToken cancellationToken)
    {
        Categories  =  await _context.Set<Category>()
            .Select(e => new SelectListItem
            {
                Text = $"Этаж: {e.Floor} Кол-во комнат: {e.NumberOfRooms} Кол-во мест: {e.NumberOfSeats}",
                Value = e.Id.ToString()
            })
            .ToListAsync(cancellationToken);

        Statuses = _htmlHelper.GetEnumSelectList<StatusEnum>();
        if (id.HasValue)
        {
            Entity = await _repository.GetById(id.Value, cancellationToken);
        }
        else
        {
            Entity = new HotelRoom();
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
            Categories  =  await _context.Set<Category>()
                .Select(e => new SelectListItem
                {
                    Text = $"Этаж: {e.Floor} Кол-во комнат: {e.NumberOfRooms} Кол-во мест: {e.NumberOfSeats}",
                    Value = e.Id.ToString()
                })
                .ToListAsync(cancellationToken);
            
            Statuses = _htmlHelper.GetEnumSelectList<StatusEnum>();

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