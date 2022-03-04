using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Player
    {
        public string name;
        public string medal;
        public Player(string name, string medal) {
            this.name = name;
            this.medal = medal;
        }
    }
}
