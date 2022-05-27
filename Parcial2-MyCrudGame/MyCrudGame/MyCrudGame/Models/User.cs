using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MyCrudGame.Models
{
    [Table("users")]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string MiddleName { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual Player Player { get; set; }
    }
}
