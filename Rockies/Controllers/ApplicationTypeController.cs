using Microsoft.AspNetCore.Mvc;
using Rockies.Data;
using Rockies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rockies.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }

        // Get Create
        public IActionResult Create()
        {
            return View();
        }

        // Post Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType objApp)
        {
            if (ModelState.IsValid)
            {

            _db.ApplicationType.Add(objApp);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }

            else
            {
                return View(objApp);
            }
        }

        // Get for Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objApp = _db.ApplicationType.Find(id);
            if (objApp == null)
            {
                return NotFound();
            }

            return View(objApp);
        }

        // Post for Update

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType objApp)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(objApp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(objApp);
            }

        }


        // Get  Delete
        public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var objApp = _db.ApplicationType.Find(id);
                if (objApp == null)
                {
                    return NotFound();
                }

                return View(objApp);
            }

            // Post Delete

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult DeletePost(int? id)
            {
                var objApp = _db.ApplicationType.Find(id);
                if (objApp == null)
                {
                    return NotFound();
                }

                _db.ApplicationType.Remove(objApp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
       
    }
}
