using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeallesService.Models;
using FeallesService.Data;
using FeallesService.Utility;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

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
        public async Task<ActionResult> GetFeallesbases(string? Fornavne, DateTime? DoedDato, int pg = 1)
        {
           
             
            var objList = await _db.Feallesbases.Where(f => f.AvisTypeID == "Bornholms Tidende").ToListAsync();


            if (!System.String.IsNullOrEmpty(Fornavne) && DoedDato != null)
            {
                objList = (List<Feallesbase>)objList.Where(b => b.Fornavne.Contains(Fornavne) && b.Doedsdato == DoedDato);

            }
            else if (System.String.IsNullOrEmpty(Fornavne) && DoedDato != null)
            {
                objList = (List<Feallesbase>)objList.Where(b => b.Doedsdato == DoedDato);
            }
            else if (!System.String.IsNullOrEmpty(Fornavne) && DoedDato == null)
            {
                objList = (List<Feallesbase>)objList.Where(b => b.Fornavne.Contains(Fornavne));
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
        public async Task<ActionResult> Create([FromBody] Feallesbase feallesbase)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _db.Feallesbases.AddAsync(feallesbase);
                    await _db.SaveChangesAsync();

                    // Assuming you want to return a 201 Created status with the created resource
                    // return CreatedAtAction("Get", new { id = feallesbase.ID }, feallesbase);
                  //  return CreatedAtAction("Get", new { ID = feallesbase.ID }, feallesbase);
                    return Ok(200);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    return BadRequest("Failed to create the resource: " + ex.Message);
                }
            }
            return BadRequest();

        }
        // PUT: api/Feallesbase/5
        [HttpPut("{ID}")]
        public async Task<IActionResult> PutFeallesbase( int ID, [FromBody] Feallesbase feallesbase)
        {
            Console.WriteLine($"Received ID: {ID}, Feallesbase: {JsonConvert.SerializeObject(feallesbase)}");

            if (ID != feallesbase.ID)
            {
                // Log the mismatch for debugging
                Console.WriteLine("ID mismatch");
                return BadRequest();
            }

            _db.Entry(feallesbase).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeallesbaseExists(ID))
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


