using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication16.Data;
using WebApplication16.Models;

namespace Forum.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _db;
     
        public MessageController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Message> objlist = _db.Messages;
            return View(objlist);
        }
        // Get
        [Authorize]
        public IActionResult Create()
        {

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Message obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Messages.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(obj);
        }
    }
}
