using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class PlayerManager
    {
        ArrayList players = new ArrayList();
        public void AddPlayer(Player player) {
            players.Add(player);
        }

        public ArrayList GetListPlayers()
        {
            return players;
        }
    }
}
