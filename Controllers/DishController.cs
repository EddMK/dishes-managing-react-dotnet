using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Controllers
{

[ApiController]
[Route("[controller]")]
public class DishController : ControllerBase
{

    //private readonly ILogger<DishController> _logger;
    private readonly IMapper _mapper;
    private readonly MainContext _context;
//ILogger<DishController> logger,
    public DishController( MainContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<Dish>> PostDish(DishDto dish )
    {

        var dishtoadd = _mapper.Map<Dish>(dish);
        _context.Dishs.Add(dishtoadd);
        await _context.SaveChangesAsync();

        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return CreatedAtAction(nameof(GetOne), new { id = dishtoadd.IdDish }, dishtoadd);
        
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dish>> GetOne(int id)
    {
        var todoItem = await _context.Dishs.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }

    [HttpGet]
    public async  Task<ActionResult<IEnumerable<Dish>>> GetAllDishs() 
    {
        return await _context.Dishs
            .Include(d => d.Category)
            .Include(d => d.Provider)
            .ToListAsync();
    }  

    [HttpDelete("{id}")]
    public async  Task<ActionResult> DeleteDish(int id) 
    {
        var dish = await _context.Dishs.FindAsync(id);
        if(dish == null){
            return BadRequest();
        }
        _context.Dishs.Remove(dish);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> PutDish(DishDto dish){
        var oldDish = await _context.Dishs.FindAsync(dish.IdDish);
        if (oldDish != null)
        {
            oldDish.Label = dish.Label;
            oldDish.Price = dish.Price;
            oldDish.CategoryId = dish.CategoryId;
            oldDish.ProviderId = dish.ProviderId;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
}
