using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SkinsPlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkinsPlayerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexSp()
        {
            IEnumerable<SkinsPlayer> sPlayer = _context.skinsPlayer;
            return View(sPlayer);
        }

        public IActionResult CreateSkinPlayer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkinPlayer(SkinsPlayer sPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.skinsPlayer.Add(sPlayer);
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexSkinPlayer");
            }
            return View();
        }

        public IActionResult EditSkinPlayer(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sPlayer = _context.skinsPlayer.Find(id);
            if (sPlayer == null)
            {
                return NotFound();
            }
            return View(sPlayer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSkinPlayer(SkinsPlayer sPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.skinsPlayer.Update(sPlayer);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexSP");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sPlayer = _context.skinsPlayer.Find(id);
            if (sPlayer == null)
            {
                return NotFound();
            }
            return View(sPlayer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSkinPlayer(int? id)
        {
            var sPlayer = _context.skinsPlayer.Find(id);
            if (sPlayer == null)
            {
                return NotFound();
            }
            _context.skinsPlayer.Remove(sPlayer);
            _context.SaveChanges();
            return RedirectToAction("IndexSP");
        }
    }
}
