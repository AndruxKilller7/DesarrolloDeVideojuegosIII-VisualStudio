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
    [Route("[controller]")]
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


    }
}
