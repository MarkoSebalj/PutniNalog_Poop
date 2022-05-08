using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;

namespace REST.API.PN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadnoMjestoController : ControllerBase
    {
        private readonly PNDbContext _dbContext;

        public RadnoMjestoController(PNDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var radnoMjesto = await _dbContext.RadnoMjesto.ToListAsync();
            return Ok(radnoMjesto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var radnoMjesto = await _dbContext.RadnoMjesto.FirstOrDefaultAsync(x => x.Id == id);
            if (radnoMjesto == null)
            {
                return NotFound("Nema zapisa");
            }
            return Ok(radnoMjesto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RadnoMjesto request)
        {
            var radnoMjesto = new RadnoMjesto()
            {
               Naziv = request.Naziv
            };

            var maxId = _dbContext.RadnoMjesto.Max(x => x.Id);
            radnoMjesto.Id = maxId + 1;

            _dbContext.RadnoMjesto.Add(radnoMjesto);

            await _dbContext.SaveChangesAsync();


            return Ok(radnoMjesto);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] RadnoMjesto request)
        {
            var radnoM = await _dbContext.RadnoMjesto.FirstOrDefaultAsync(x => x.Id == id);
            if (radnoM == null)
            {
                return NotFound();
            }

            radnoM.Naziv = request.Naziv;


            await _dbContext.SaveChangesAsync();


            return Ok(radnoM);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var radnoM = await _dbContext.RadnoMjesto.FirstOrDefaultAsync(x => x.Id == id);
            if (radnoM == null)
            {
                return NotFound();
            }

            _dbContext.RadnoMjesto.Remove(radnoM);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
