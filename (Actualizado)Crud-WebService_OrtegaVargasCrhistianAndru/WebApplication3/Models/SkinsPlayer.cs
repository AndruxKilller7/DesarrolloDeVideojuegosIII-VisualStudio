using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class SkinsPlayer
    {
        [Key]
        public int IdPlayer { get; set; }
        public int IdSkin { get; set; }

        
        public string NameSkin { get; set; }


    }
}
