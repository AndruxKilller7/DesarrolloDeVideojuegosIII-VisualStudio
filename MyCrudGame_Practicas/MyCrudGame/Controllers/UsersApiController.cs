using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCrudGame.Data;
using MyCrudGame.Models;
using Microsoft.EntityFrameworkCore;

namespace MyCrudGame.Controllers
{
    [ApiController]
    [Route("api/usersApi1")]
    public class UsersApiController : Controller
    {
        private readonly CRUDMyGameContext _context;

        public UsersApiController(CRUDMyGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get(int id)
        
        {
            IEnumerable<User> users = _context.Users;
            return users;
        }

        
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<User>  GetAll(int id)

        {
            var user = await _context.Users
                .Include(p =>p.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            return user;
        }

        // POST: api/User

        [HttpPost]

        public async Task<ActionResult<User>> Authenticate([FromForm] User user)
        {
            var userResult = await Task.Run(() => _context.Users.SingleOrDefault(x => x.Email == user.Email && x.Pasword == user.Pasword));
            if (userResult == null)
            {
                return null;
            }

            var player = await _context.Players.Include(P => P.Ranks).Include(p => p.IdNavigation).Include(p => p.PlayerSkins).FirstOrDefaultAsync(m => m.Id == userResult.Id);
            return CreatedAtAction("GetPlayer", new { id = player.Id }, player.Id);

            

        }
    }
}
