using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class RankController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RankController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexRank()
        {
            IEnumerable<Rank> rank = _context.rank;
            return View(rank);
        }

        public IActionResult CreateRank()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRank(Rank rank)
        {
            if (ModelState.IsValid)
            {
                _context.rank.Add(rank);
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexRank");
            }
            return View();
        }

        public IActionResult EditRank(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var rank = _context.rank.Find(id);
            if (rank == null)
            {
                return NotFound();
            }
            return View(rank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRank(Rank rank)
        {
            if (ModelState.IsValid)
            {
                _context.rank.Update(rank);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexRank");
            }
            return View();
        }

        
        public ActionResult DeleteRank(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var rank = _context.rank.Find(id);
            if (rank == null)
            {
                return NotFound();
            }
            return View(rank);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? IdPlayer)
        {
            var rank = _context.rank.Find(IdPlayer);
            if (rank == null)
            {
                return NotFound();
            }
            _context.rank.Remove(rank);
            _context.SaveChanges();
            return RedirectToAction("IndexRank");
        }
    }
}
