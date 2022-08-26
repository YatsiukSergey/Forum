using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApplication16.Data;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class ThemeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ThemeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Theme> objlist = _db.Themes;
            return View(objlist);
        }
        // Get
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Theme obj)
        {
            if (ModelState.IsValid)
            {
                _db.Themes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(obj);
           
        }
        public IActionResult Edit(int? id)
        {
            if (id == null||id==0)
            {
                return NotFound();
            }
            var obj = _db.Themes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Theme obj)
        {
            if (ModelState.IsValid)
            {
                _db.Themes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(obj);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Themes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Themes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.Themes.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

         
        }
    }
}
