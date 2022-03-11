using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Achievements
    {
        [Key]
        public int IdPlayer { get; set; }

        
        public string Name { get; set; }


        [Required(ErrorMessage = "This field is required")]
        
        public string Grade { get; set; }

        [Required(ErrorMessage = "This field is required")]
        
        public int Value { get; set; }

        public DateTime RegistrationDate { get; set; }

    }
}
