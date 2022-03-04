using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace mvcconreact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

      

        public IActionResult Index()
        {
            PlayerManager manager = new PlayerManager();

            Player player1 = new Player("Aldo Barrera", "Bronce");
            manager.AddPlayer(player1);
            Player player2 = new Player("VirtualXi", "Bronce");
            manager.AddPlayer(player2);
            Player player3 = new Player("Ninja", "Bronce");
            manager.AddPlayer(player3);
            Player player4 = new Player("Killer", "Bronce");
            manager.AddPlayer(player4);


            ArrayList players = manager.GetListPlayers();

            ViewData["ranks"] = players;
            ViewBag.data = players;
            return View();
        }
    }
}
