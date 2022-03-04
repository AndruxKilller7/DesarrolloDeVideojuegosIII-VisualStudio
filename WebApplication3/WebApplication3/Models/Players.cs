using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication3.Models
{
    public class Players
    {
        [Key]
        public int IdUser { get; set; }

        public string PlayerName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        public int PointsXP { get; set; }

      

        public string Ranking { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]

        public int Skins { get; set; }


        public int Achivements { get; set; }

       
        public int Items { get; set; }


        public int Lifes { get; set; }

  
        public string CurrentStateOfProgress { get; set; }








       
    }

}
