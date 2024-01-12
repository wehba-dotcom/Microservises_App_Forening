using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeallesService.Models;
using FeallesService.Data;
using FeallesService.Utility;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FeallesService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FeallesbaseController : ControllerBase

    {
       

        private readonly AppDbContext _db;
      
        public FeallesbaseController(AppDbContext db)
        {
            _db = db;
           
        }

        // GET: api/Feallesbase
        [HttpGet]
        public async Task<ActionResult> GetFeallesbases(string? Firstname, DateTime? DoedDato, int pg = 1)
        {
           
             
            var objList = await _db.Feallesbases.Where(f => f.AvisTypeID == "Bornholms Tidende").ToListAsync();


            if (!System.String.IsNullOrEmpty(Firstname) && DoedDato != null)
            {
                objList = (List<Feallesbase>)objList.Where(b => b.Fornavne.Contains(Firstname) && b.Doedsdato == DoedDato);

            }
            else if (System.String.IsNullOrEmpty(Firstname) && DoedDato != null)
            {
                objList = (List<Feallesbase>)objList.Where(b => b.Doedsdato == DoedDato);
            }
            else if (!System.String.IsNullOrEmpty(Firstname) && DoedDato == null)
            {
                objList = (List<Feallesbase>)objList.Where(b => b.Fornavne.Contains(Firstname));
            }
            //const int pageSize = 100;
         
            //if (pg < 1)
            //{
            //    pg = 1;
            //}
            //int recsCount = objList.Count();
            //var pager = new Pager(recsCount, pg, pageSize);
            //int resSkip = (pg - 1) * pageSize;
            

            
                
                   // var data = await objList.Skip(resSkip).Take(pager.PageSize).ToListAsync();
                  
                // Process 'data' or return it as needed
                return Ok(objList); // Return HTTP 200 OK with the 'data'
                
   

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


