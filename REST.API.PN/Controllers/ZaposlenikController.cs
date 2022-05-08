using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;

namespace REST.API.PN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposlenikController : ControllerBase
    {
        private readonly PNDbContext _dbContext;

        public ZaposlenikController(PNDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var zaposlenik = await _dbContext.Zaposlenik.ToListAsync();
            return Ok(zaposlenik);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var zaposlenik = await _dbContext.Zaposlenik.FirstOrDefaultAsync(x => x.Id == id);
            if (zaposlenik == null)
            {
                return NotFound("Nema zapisa");
            }
            return Ok(zaposlenik);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Zaposlenik request)
        {
            var zaposlenik = new Zaposlenik()
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                UkupniIznosTroska = request.UkupniIznosTroska,
                RadnoMjesto = request.RadnoMjesto,
                PutniTroskovi = request.PutniTroskovi,
            };

            var maxId = _dbContext.Zaposlenik.Max(x => x.Id);
            zaposlenik.Id = maxId + 1;

            _dbContext.Zaposlenik.Add(zaposlenik);

            await _dbContext.SaveChangesAsync();


            return Ok(zaposlenik);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Zaposlenik request)
        {
            var zaposlenik = await _dbContext.Zaposlenik.FirstOrDefaultAsync(x => x.Id == id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            zaposlenik.Ime = request.Ime;
            zaposlenik.Prezime = request.Prezime;
            zaposlenik.UkupniIznosTroska = request.UkupniIznosTroska;
            zaposlenik.RadnoMjesto = request.RadnoMjesto;
            zaposlenik.PutniTroskovi = request.PutniTroskovi;
           


            await _dbContext.SaveChangesAsync();


            return Ok(zaposlenik);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var zaposlenik = await _dbContext.Zaposlenik.FirstOrDefaultAsync(x => x.Id == id);
            if (zaposlenik == null)
            {
                return NotFound();
            }

            _dbContext.Zaposlenik.Remove(zaposlenik);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
