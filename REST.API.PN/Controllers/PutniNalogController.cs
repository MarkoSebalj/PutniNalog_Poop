using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;

namespace REST.API.PN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutniNalogController : ControllerBase
    {
        private readonly PNDbContext _dbContext;

        public PutniNalogController(PNDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var putniNalog = await _dbContext.PutniNalog.ToListAsync();
            return Ok(putniNalog);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var putniNalog = await _dbContext.PutniNalog.FirstOrDefaultAsync(x => x.Id == id);
            if (putniNalog == null)
            {
                return NotFound("Nema zapisa");
            }
            return Ok(putniNalog);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PutniNalog request)
        {
            var putniNalog = new PutniNalog()
            {
                DatumKraja = request.DatumKraja,
                DatumPocetka = request.DatumPocetka,
                MjestoPutovanja = request.MjestoPutovanja,
                Vozilo = request.Vozilo,
                Zaposlenik = request.Zaposlenik
            };

            var maxId = _dbContext.PutniNalog.Max(x => x.Id);
            putniNalog.Id = maxId + 1;

            _dbContext.PutniNalog.Add(putniNalog);

            await _dbContext.SaveChangesAsync();


            return Ok(putniNalog);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] PutniNalog request)
        {
            var putniN = await _dbContext.PutniNalog.FirstOrDefaultAsync(x => x.Id == id);
            if (putniN == null)
            {
                return NotFound();
            }

            putniN.DatumPocetka = request.DatumPocetka;
            putniN.DatumKraja = request.DatumKraja;
            putniN.MjestoPutovanja = request.MjestoPutovanja;
            putniN.Vozilo = request.Vozilo;
            putniN.Zaposlenik = request.Zaposlenik;


            await _dbContext.SaveChangesAsync();


            return Ok(putniN);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var putniN = await _dbContext.PutniNalog.FirstOrDefaultAsync(x => x.Id == id);
            if (putniN == null)
            {
                return NotFound();
            }

            _dbContext.PutniNalog.Remove(putniN);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
