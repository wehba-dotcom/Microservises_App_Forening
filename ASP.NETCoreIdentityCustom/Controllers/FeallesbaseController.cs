
using Bornholm_Slægts.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using Microsoft.IdentityModel.Tokens;

using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

using String = System.String;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Bornholm_Sleagts.Areas.Identity.Data;
using Bornholm_Sleagts.Models;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Drawing.Charts;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2016.Excel;

namespace Bornholm_Slægts.Controllers
{



    public class FeallesbaseController : Controller
    {


        private readonly IHttpClientFactory _httpClientFactory;
        public FeallesbaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize(Policy = "RequireManager")]

        public async Task<IActionResult> Index(string? Firstname, DateTime? DoedDato, int pg)
        {
            var client = _httpClientFactory.CreateClient("MyClient");


            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8000/Feallesbase");

            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Alert = $"Noget er galt! Grunden: {response.ReasonPhrase}";
                return View();
            }

            // var feallesbaseobj = JsonConvert.DeserializeObject<Feallesbase>(result);
            List<Feallesbase>? convert = JsonConvert.DeserializeObject<List<Feallesbase>>(result) as List<Feallesbase>;


            //if (!String.IsNullOrEmpty(Firstname) && DoedDato != null)
            //{
            //    convert = convert.Where(b => b.Fornavne.Contains(Firstname) && b.Doedsdato == DoedDato);

            //}
            //else if (String.IsNullOrEmpty(Firstname) && DoedDato != null)
            //{
            //    objList = objList.Where(b => b.Doedsdato == DoedDato);
            //}
            //else if (!String.IsNullOrEmpty(Firstname) && DoedDato == null)
            //{
            //    objList = objList.Where(b => b.Fornavne.Contains(Firstname));
            //}

            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = convert.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int resSkip = (pg - 1) * pageSize;
            var data = convert.Skip(resSkip).Take(pager.PageSize).ToList();

            //var data = objLists.ToList();
            this.ViewBag.Pager = pager;

            return View(data);

        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Feallesbase feallesbase)
        {

            using (var client = _httpClientFactory.CreateClient("MyClient"))
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:8000/Feallesbase?feallesbase={feallesbase}");

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    List<Feallesbase>? convert = JsonConvert.DeserializeObject<List<Feallesbase>>(result);


                    convert.Add(feallesbase);
                    TempData["success"] = "En annonccer tilføjet successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Alert = $"Noget er galt! Grunden: {response.ReasonPhrase}";
                    return View();
                }

            }

            // If ModelState is not valid, return the View with errors
            return View();
        }


    }
}


        //private readonly ApplicationDbContext _db;
        //public FeallesbaseController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        //public async Task<IActionResult> Index(string? Firstname, DateTime? DoedDato, int pg)
        //{
        //    // ViewData["DateSortParm"] = Firstname == "DateTime" ? "Avisdato" : "DateTime";
        //    var objList = from b in _db.Feallesbases select b;

        //    if (!String.IsNullOrEmpty(Firstname) && DoedDato != null)
        //    {
        //        objList = objList.Where(b => b.Fornavne.Contains(Firstname) && b.Doedsdato == DoedDato);

        //    }
        //    else if (String.IsNullOrEmpty(Firstname) && DoedDato != null)
        //    {
        //        objList = objList.Where(b => b.Doedsdato == DoedDato);
        //    }
        //    else if (!String.IsNullOrEmpty(Firstname) && DoedDato == null)
        //    {
        //        objList = objList.Where(b => b.Fornavne.Contains(Firstname));
        //    }

        //    const int pageSize = 5;
        //    if (pg < 1)
        //    {
        //        pg = 1;
        //    }
        //    int recsCount = objList.Count();
        //    var pager = new Pager(recsCount, pg, pageSize);
        //    int resSkip = (pg - 1) * pageSize;
        //    var objLists = await _db.Feallesbases.Where(f => f.AvisTypeID == "Bornholms Tidende").ToListAsync();

        //    var data =  objLists.ToList();
        //    this.ViewBag.Pager = pager;


        //    return View(data);
        //}


        //public IActionResult Delete(int? id)
        //{
        //    if(id==0 || id == null)
        //    {
        //        return NotFound();

        //    }
        //    var obj = _db.Feallesbases.Find(id);
        //    if(obj==null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        //public IActionResult Update(int? ID)
        //{
        //    if (ID == null || ID == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.Feallesbases.Find(ID);
        //    if(obj==null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}
        //[HttpGet]
        //public IActionResult Search(DateTime DeadDate, string Firstname)
        //{
        //    var objList = from b in _db.Feallesbases select b;
        //    if (DeadDate != null && Firstname == "")
        //    {
        //        objList = objList.Where(s => s.Doedsdato == (DeadDate));
        //        return View(objList);
        //    }

        //    else if (DeadDate == null && Firstname != "")

        //    {
        //        objList = objList.Where(s => s.Fornavne.Contains(Firstname));
        //        return View(objList);
        //    }else if(DeadDate !=null && Firstname !="" )
        //    {
        //        objList = objList.Where(s => s.Fornavne.Contains(Firstname) & s.Doedsdato==DeadDate);
        //        return View(objList);
        //    }
        //    return View("Index");

        //}

        //[HttpPost]
        //public IActionResult DeletePost(int? id)
        //{
        //    var obj = _db.Feallesbases.Find(id);
        //    if ( id==null || id==0)
        //    {
        //        return NotFound();
        //    }

        //    _db.Feallesbases.Remove(obj);
        //    _db.SaveChanges();
        //    TempData["success"] = "En annoncer sletet successfully";
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult SearchGet(int? ID)
        //{
        //    var obj = _db.Feallesbases.Find(ID);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //   if(obj==null)
        //    {
        //        return NotFound();
        //    }
        //    return RedirectToAction("Index");
        //}



        //[HttpPost]
        //public IActionResult Update(Feallesbase feallesbase)
        //{
        //  if(ModelState.IsValid)
        //    {
        //        _db.Entry(feallesbase).State = EntityState.Modified;
        //        _db.SaveChanges();
        //        TempData["success"] = "Anoncer Redigere successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

    
    

