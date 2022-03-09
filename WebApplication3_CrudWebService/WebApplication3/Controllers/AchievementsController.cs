using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AchievementsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexAchievements()
        {
            IEnumerable<Achievements> achievement = _context.achievement;
            return View(achievement);
        }

        public IActionResult CreateAchievement()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAchievement(Achievements achievement)
        {
            if (ModelState.IsValid)
            {
                _context.achievement.Add(achievement);
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexAchievements");
            }
            return View();
        }

        public IActionResult EditAchievement(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var user = _context.achievement.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAchievement(Achievements achievement)
        {
            if (ModelState.IsValid)
            {
                _context.achievement.Update(achievement);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexAchievements");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var achievement = _context.achievement.Find(id);
            if (achievement == null)
            {
                return NotFound();
            }
            return View(achievement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAchievement(int? id)
        {
            var achievement = _context.achievement.Find(id);
            if (achievement == null)
            {
                return NotFound();
            }
            _context.achievement.Remove(achievement);
            _context.SaveChanges();
            return RedirectToAction("IndexAchievements");
        }
    }
}
