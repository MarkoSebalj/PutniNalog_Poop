using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;

namespace REST.API.PN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VrstaTroskaController : ControllerBase
    {
        private readonly PNDbContext _dbContext;

        public VrstaTroskaController(PNDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var vrtsaTroska = await _dbContext.VrstaTroska.ToListAsync();
            return Ok(vrtsaTroska);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var vrstaTroska = await _dbContext.VrstaTroska.FirstOrDefaultAsync(x => x.Id == id);
            if (vrstaTroska == null)
            {
                return NotFound("Nema zapisa");
            }
            return Ok(vrstaTroska);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] VrstaTroska request)
        {
            var VrstaTroska = new VrstaTroska()
            {
                Naziv = request.Naziv
               
            };
            var maxId = _dbContext.VrstaTroska.Max(x => x.Id);
            VrstaTroska.Id = maxId + 1;

            _dbContext.VrstaTroska.Add(VrstaTroska);

            await _dbContext.SaveChangesAsync();


            return Ok(VrstaTroska);
        }

        [HttpPut("id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] VrstaTroska request)
        {
            var nazivV = await _dbContext.VrstaTroska.FirstOrDefaultAsync(x => x.Id == id);
            if (nazivV == null)
            {
                return NotFound();
            }

            nazivV.Naziv = request.Naziv;
            
            await _dbContext.SaveChangesAsync();


            return Ok(nazivV);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var nazivV = await _dbContext.VrstaTroska.FirstOrDefaultAsync(x => x.Id == id);
            if (nazivV == null)
            {
                return NotFound();
            }

            _dbContext.VrstaTroska.Remove(nazivV);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        }
    }
}
