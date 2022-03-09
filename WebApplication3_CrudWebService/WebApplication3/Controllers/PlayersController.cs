using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexPlayer()
        {
            IEnumerable<Players> players = _context.players;
            return View(players);
        }

        public IActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePlayer(Players player)
        {
            if (ModelState.IsValid)
            {
                _context.players.Add(player);
                _context.SaveChanges();

                TempData["message"] = "The user was created correctly";
                return RedirectToAction("IndexPlayer");
            }
            return View();
        }

        public IActionResult EditPlayer(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var player = _context.players.Find(id);
            if (player==null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPlayer(Players player)
        {
            if (ModelState.IsValid)
            {
                _context.players.Update(player);
                _context.SaveChanges();

                TempData["message"] = "The user was updated correctly";
                return RedirectToAction("IndexPlayer");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var player = _context.players.Find(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePlayer(int? idUser)
        {
            var player = _context.players.Find(idUser);
            if (player == null)
            {
                return NotFound();
            }
            _context.players.Remove(player);
            _context.SaveChanges();
            return RedirectToAction("IndexPlayer");
        }
    }
}
