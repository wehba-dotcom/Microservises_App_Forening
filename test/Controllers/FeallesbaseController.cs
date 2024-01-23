using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;

namespace test.Controllers
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
        public async Task<ActionResult> GetFeallesbases()
        {
            try
            {
                //Where(f => f.AvisTypeID == "Bornholms Tidende")
                var objList = await _db.Feallesbases.ToListAsync();

                //const int pageSize = 10;
                //int pg = 1;
                //if (pg < 1)
                //{
                //    pg = 1;
                //}
                //int recsCount = objList.Count();
                //var pager = new Pager(recsCount, pg, pageSize);
                //int resSkip = (pg - 1) * pageSize;

                //var data = objList.Skip(resSkip).Take(pager.PageSize);
                return Ok(objList);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
