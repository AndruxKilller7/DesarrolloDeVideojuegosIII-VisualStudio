using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Skins
    {
        [Key]
        public int IdSkin { get; set; }


       
        public string Grade { get; set; }

        [Required(ErrorMessage = "This field is required")]
        
        public int Value { get; set; }

       

        public string Category { get; set; }

        [Required(ErrorMessage = "This field is required")]
       
        public string RankRequiredToUnlock { get; set; }




    }
}
