using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;

namespace REST.API.PN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoziloController : ControllerBase
    {
        private readonly PNDbContext _dbContext;

        public VoziloController(PNDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var vozilo = await _dbContext.Vozilo.ToListAsync();
            return Ok(vozilo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var Vozilo = await _dbContext.Vozilo.FirstOrDefaultAsync(x => x.Id == id);
            if (Vozilo == null)
            {
                return NotFound("Nema zapisa");
            }
            return Ok(Vozilo);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Vozilo request)
        {
            var Vozilo = new Vozilo()
            {
                Marka = request.Marka,
                Registracija = request.Registracija
            };
            var maxId = _dbContext.Vozilo.Max(x => x.Id);
            Vozilo.Id = maxId + 1;

            _dbContext.Vozilo.Add(Vozilo);

            await _dbContext.SaveChangesAsync();


            return Ok(Vozilo);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Vozilo request)
        {
            var nazivV = await _dbContext.Vozilo.FirstOrDefaultAsync(x => x.Id == id);
            if (nazivV == null)
            {
                return NotFound();
            }

            nazivV.Marka = request.Marka;
            nazivV.Registracija = request.Registracija;

            await _dbContext.SaveChangesAsync();


            return Ok(nazivV);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var nazivV = await _dbContext.Vozilo.FirstOrDefaultAsync(x => x.Id == id);
            if (nazivV == null)
            {
                return NotFound();
            }

            _dbContext.Vozilo.Remove(nazivV);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
