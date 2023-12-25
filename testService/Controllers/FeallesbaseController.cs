using FælesbasesService.Areas.Identity.Data;
using FælesbasesService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeallesbaseController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Replace YourDbContext with your actual DbContext

        public FeallesbaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Feallesbase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feallesbase>>> GetFeallesbases()
        {
            return await _context.Feallesbases.ToListAsync();
        }

        // GET: api/Feallesbase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feallesbase>> GetFeallesbase(int id)
        {
            var feallesbase = await _context.Feallesbases.FindAsync(id);

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
            _context.Feallesbases.Add(feallesbase);
            await _context.SaveChangesAsync();

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

            _context.Entry(feallesbase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            var feallesbase = await _context.Feallesbases.FindAsync(id);
            if (feallesbase == null)
            {
                return NotFound();
            }

            _context.Feallesbases.Remove(feallesbase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeallesbaseExists(int id)
        {
            return _context.Feallesbases.Any(e => e.ID == id);
        }
    }
}
