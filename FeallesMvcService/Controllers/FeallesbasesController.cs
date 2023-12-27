using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeallesMvcService.Data;
using FeallesMvcService.Models;

namespace FeallesMvcService.Controllers
{
    
    public class FeallesbasesController : Controller
    {
        private readonly AppDbContext _context;

        public FeallesbasesController(AppDbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            try
            {
                var objList = _context.Feallesbases.ToList();
               
                // Example: Checking for null values before using the property
                foreach (var obj in objList)
                {
                    if (obj.Oegenavne == null)
                    {
                        // Handle null value case accordingly
                    }
                    else
                    {
                        // Perform operations on obj.PropertyName
                    }
                }

                return View(objList);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: " + ex.Message);
            }
        }


        //        // GET: api/Feallesbases
        //        [HttpGet]
        //        public async Task<ActionResult<IEnumerable<Feallesbase>>> GetFeallesbase()
        //        {
        //          if (_context.Feallesbase == null)
        //          {
        //              return NotFound();
        //          }
        //            return await _context.Feallesbase.ToListAsync();
        //        }

        //        // GET: api/Feallesbases/5
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<Feallesbase>> GetFeallesbase(int id)
        //        {
        //          if (_context.Feallesbase == null)
        //          {
        //              return NotFound();
        //          }
        //            var feallesbase = await _context.Feallesbase.FindAsync(id);

        //            if (feallesbase == null)
        //            {
        //                return NotFound();
        //            }

        //            return feallesbase;
        //        }

        //        // PUT: api/Feallesbases/5
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutFeallesbase(int id, Feallesbase feallesbase)
        //        {
        //            if (id != feallesbase.ID)
        //            {
        //                return BadRequest();
        //            }

        //            _context.Entry(feallesbase).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!FeallesbaseExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // POST: api/Feallesbases
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPost]
        //        public async Task<ActionResult<Feallesbase>> PostFeallesbase(Feallesbase feallesbase)
        //        {
        //          if (_context.Feallesbase == null)
        //          {
        //              return Problem("Entity set 'AppDbContext.Feallesbase'  is null.");
        //          }
        //            _context.Feallesbase.Add(feallesbase);
        //            await _context.SaveChangesAsync();

        //            return CreatedAtAction("GetFeallesbase", new { id = feallesbase.ID }, feallesbase);
        //        }

        //        // DELETE: api/Feallesbases/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteFeallesbase(int id)
        //        {
        //            if (_context.Feallesbase == null)
        //            {
        //                return NotFound();
        //            }
        //            var feallesbase = await _context.Feallesbase.FindAsync(id);
        //            if (feallesbase == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Feallesbase.Remove(feallesbase);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool FeallesbaseExists(int id)
        //        {
        //            return (_context.Feallesbase?.Any(e => e.ID == id)).GetValueOrDefault();
        //        }
    }
}
