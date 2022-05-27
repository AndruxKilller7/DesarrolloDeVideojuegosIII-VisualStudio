using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCrudGame.Data;
using MyCrudGame.Models;

namespace MyCrudGame.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class Players1Controller : ControllerBase
    {
        private readonly CRUDMyGameContext _context;

        public Players1Controller(CRUDMyGameContext context)
        {
            _context = context;
        }

        // GET: api/Players1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        // GET: api/Players1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.Include(p => p.Ranks).Include(p => p.IdNavigation).Include(p => p.PlayerSkins).ThenInclude(x => x.Skin)
                .FirstOrDefaultAsync(m => m.Id == id); ;

                if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Player>> PutPlayer(int id, Player player)
        {
            var PlayerExist = await Task.Run(() => _context.Players.SingleOrDefault(x => x.NickName == player.NickName));

            if (id != player.Id && PlayerExist != null)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var playerResult = await _context.Players.Include(p => p.Ranks).Include(p => p.IdNavigation).Include(p => p.PlayerSkins).ThenInclude(x => x.Skin)
              .FirstOrDefaultAsync(m => m.Id == id); ;

                if (playerResult == null)
                {
                    return NoContent();
                }
                return playerResult;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

           

           
            return NoContent();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlayer(int id, [FromBody] Player player)
        //{
        //    var playerResult = await Task.Run(() => _context.Players.SingleOrDefault(x => x.NickName == player.NickName));
        //    if (playerResult == null)
        //    {
        //        if (id != player.Id)
        //        {
        //            return BadRequest();
        //        }


        //        _context.Entry(player).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PlayerExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return NoContent();
        //    }

        //    return null;



        //}

        // POST: api/Players1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer([FromForm] Player player)
        {
            _context.Players.Add(player);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerExists(player.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        // DELETE: api/Players1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
