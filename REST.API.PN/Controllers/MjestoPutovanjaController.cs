using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PutniNalogDataContext.PN.Database;

namespace REST.API.PN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MjestoPutovanjaController : ControllerBase
    {
        private readonly PNDbContext _dbContext;

        public MjestoPutovanjaController(PNDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var mjestoPutovanja = await _dbContext.MjestoPutovanja.ToListAsync();
            return Ok(mjestoPutovanja);
        }
    }
}
