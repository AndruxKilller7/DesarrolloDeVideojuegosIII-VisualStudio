using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication3.Models
{
    public class Rank
    {
        [Key]
        public int IdPlayer { get; set; }

       
        public int PointsXP { get; set; }

      

        public int Damage { get; set; }

       

        public int BossesEliminated { get; set; }

       

        public int ItemUse { get; set; }

     

        public DateTime Time { get; set; }


     


        public string FinalRank { get; set; }
    }
}
