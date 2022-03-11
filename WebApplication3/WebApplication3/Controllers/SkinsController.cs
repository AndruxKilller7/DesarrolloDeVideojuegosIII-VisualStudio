using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SkinsController: Controller
    {
        private readonly ApplicationDbContext _context;

        public SkinsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexSkin()
        {
            IEnumerable<Skins> skins = _context.skins;
            return View(skins);
        }

        public IActionResult CreateSkin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkin(Skins skins)
        {
            if (ModelState.IsValid)
            {
                _context.skins.Add(skins);
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexSkin");
            }
            return View();
        }

        public IActionResult EditSkin(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var skins = _context.skins.Find(id);
            if (skins==null)
            {
                return NotFound();
            }
            return View(skins);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSkin(Skins skins)
        {
            if (ModelState.IsValid)
            {
                _context.skins.Update(skins);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexSkin");
            }
                                                          return View();
        }

        public IActionResult DeleteSkins(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var skins = _context.skins.Find(id);
            if (skins == null)
            {
                return NotFound();
            }
            return View(skins);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? IdSkin)
        {
            var skins = _context.skins.Find(IdSkin);
            if (skins == null)
            {
                return NotFound();
            }
            _context.skins.Remove(skins);
            _context.SaveChanges();
            return RedirectToAction("IndexSkin");
        }
    }
}
