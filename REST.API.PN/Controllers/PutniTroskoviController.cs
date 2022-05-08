using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;

namespace REST.API.PN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutniTroskoviController : ControllerBase
    {
        private readonly PNDbContext _dbContext;

        public PutniTroskoviController(PNDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var putniTroskovi = await _dbContext.PutniTroskovi.ToListAsync();
            return Ok(putniTroskovi);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var putniTroskovi = await _dbContext.PutniTroskovi.FirstOrDefaultAsync(x => x.Id == id);
            if (putniTroskovi == null)
            {
                return NotFound("Nema zapisa");
            }
            return Ok(putniTroskovi);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PutniTroskovi request)
        {
            var putniTroskovi = new PutniTroskovi()
            {
                IznosTroska = request.IznosTroska,
                VrstaTroska = request.VrstaTroska
            };

            var maxId = _dbContext.PutniTroskovi.Max(x => x.Id);
            putniTroskovi.Id = maxId + 1;

            _dbContext.PutniTroskovi.Add(putniTroskovi);

            await _dbContext.SaveChangesAsync();


            return Ok(putniTroskovi);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] PutniTroskovi request)
        {
            var putniT = await _dbContext.PutniTroskovi.FirstOrDefaultAsync(x => x.Id == id);
            if (putniT == null)
            {
                return NotFound();
            }

            putniT.IznosTroska = request.IznosTroska;
            putniT.VrstaTroska = request.VrstaTroska;


            await _dbContext.SaveChangesAsync();


            return Ok(putniT);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var putniT = await _dbContext.PutniTroskovi.FirstOrDefaultAsync(x => x.Id == id);
            if (putniT == null)
            {
                return NotFound();
            }

            _dbContext.PutniTroskovi.Remove(putniT);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
