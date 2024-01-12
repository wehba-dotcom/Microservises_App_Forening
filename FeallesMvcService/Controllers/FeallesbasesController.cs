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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feallesbase feallesbase)
        {

            if (ModelState.IsValid)
            {
                _context.Feallesbases.Add(feallesbase);
                _context.SaveChanges();
                TempData["success"] = "En annonccer tilføjet successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
                       
    }
}
