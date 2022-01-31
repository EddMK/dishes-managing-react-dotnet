using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly MainContext _context;

        public CategoryController(ILogger<CategoryController> logger, MainContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Category>>> GetAllCategories() 
        {
            return await _context.Categories.ToListAsync();
        }  
    }
}