using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProviderController : ControllerBase
    {

        private readonly ILogger<ProviderController> _logger;
        private readonly MainContext _context;

        public ProviderController(ILogger<ProviderController> logger, MainContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Provider>>> GetAllCategories() 
        {
            return await _context.Providers.ToListAsync();
        }  
    }
}