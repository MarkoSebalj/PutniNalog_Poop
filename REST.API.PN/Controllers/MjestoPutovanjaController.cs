using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var mjestoPutovanja = await _dbContext.MjestoPutovanja.FirstOrDefaultAsync(x => x.Id == id);
            if (mjestoPutovanja == null)
            {
                return NotFound("Nema zapisa");
            }
            return Ok(mjestoPutovanja);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MjestoPutovanja request)
        {
            var mjestoPutovanja = new MjestoPutovanja()
            {
                NazivMjesta = request.NazivMjesta
            };
            var maxId =  _dbContext.MjestoPutovanja.Max(x => x.Id);
            mjestoPutovanja.Id = maxId+1;

            _dbContext.MjestoPutovanja.Add(mjestoPutovanja);

            await _dbContext.SaveChangesAsync();

           
            return Ok(mjestoPutovanja);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] MjestoPutovanja request)
        {
            var mjestoP = await _dbContext.MjestoPutovanja.FirstOrDefaultAsync(x => x.Id==id);
            if (mjestoP == null)
            {
                return NotFound();
            }

            mjestoP.NazivMjesta = request.NazivMjesta;

            await _dbContext.SaveChangesAsync();


            return Ok(mjestoP);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var mjestoP = await _dbContext.MjestoPutovanja.FirstOrDefaultAsync(x => x.Id == id);
            if (mjestoP == null)
            {
                return NotFound();
            }

            _dbContext.MjestoPutovanja.Remove(mjestoP);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
