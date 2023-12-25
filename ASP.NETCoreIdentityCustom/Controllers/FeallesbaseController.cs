
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

namespace Bornholm_Slægts.Controllers
{
    public class FeallesbaseController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public FeallesbaseController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetBases()
        {
            // Creating an HTTP client instance
            var client = _clientFactory.CreateClient("MyClient");

            // Forming a GET request with query parameters
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://WebApplication2/Feallesbase/GetFeallesbases");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            // Handling non-success status codes
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Alert = $"Noget er galt! Grunden: {response.ReasonPhrase}";
                return View("Index");
            }

            // Deserializing response content into BMI object and rounding off the BMI value
            var bmiObj = JsonConvert.DeserializeObject<Feallesbase>(result);



            return View("Index");
        }

        //public IActionResult Create()
        //{
        //    return View();
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
        //public IActionResult Create(Feallesbase feallesbase)
        //{

        //    if(ModelState.IsValid)
        //    {
        //        _db.Feallesbases.Add(feallesbase);
        //        _db.SaveChanges();
        //        TempData["success"] = "En annonccer tilføjet successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();

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
    }
}

