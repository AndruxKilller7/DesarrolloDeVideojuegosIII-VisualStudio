using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOfBirthday { get; set; }

        
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]

        
       

        public string LastName { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]

        

        public string Gmail { get; set; }
       
        
        public int CellPhone { get; set; }

        




    }
}
