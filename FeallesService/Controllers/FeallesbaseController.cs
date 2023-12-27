using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeallesService.Models;
using FeallesService.Data;
using FeallesService.Utility;

namespace FeallesService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FeallesbaseController : ControllerBase

    {
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
       };

        private readonly AppDbContext _db;
        private readonly ILogger<FeallesbaseController> _logger;
        public FeallesbaseController(ILogger<FeallesbaseController> logger,AppDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        // GET: api/Feallesbase
        [HttpGet]
        public async Task<ActionResult> GetFeallesbases()
        {
            var objList = from b in _db.Feallesbases select b;
            const int pageSize = 2;
            int pg = 1;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = objList.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int resSkip = (pg - 1) * pageSize;
            var data = await objList.Skip(resSkip).Take(pager.PageSize).ToListAsync();
            return Ok(data);
        }

        // GET: api/Feallesbase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feallesbase>> GetFeallesbase(int id)
        {
            var feallesbase = await _db.Feallesbases.FindAsync(id);

            if (feallesbase == null)
            {
                return NotFound();
            }

            return feallesbase;
        }

        // POST: api/Feallesbase
        [HttpPost]
        public async Task<ActionResult<Feallesbase>> PostFeallesbase(Feallesbase feallesbase)
        {
            _db.Feallesbases.Add(feallesbase);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeallesbase), new { id = feallesbase.ID }, feallesbase);
        }

        // PUT: api/Feallesbase/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeallesbase(int id, Feallesbase feallesbase)
        {
            if (id != feallesbase.ID)
            {
                return BadRequest();
            }

            _db.Entry(feallesbase).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeallesbaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Feallesbase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeallesbase(int id)
        {
            var feallesbase = await _db.Feallesbases.FindAsync(id);
            if (feallesbase == null)
            {
                return NotFound();
            }

            _db.Feallesbases.Remove(feallesbase);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool FeallesbaseExists(int id)
        {
            return _db.Feallesbases.Any(e => e.ID == id);
        }

    }
}


