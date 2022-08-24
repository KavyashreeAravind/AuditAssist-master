using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AuthorizationService.Model
{
    public partial class Userdetails
    {
        [Key]
        
        public int Userid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Email { get; set; }

        public string? Password { get; set; }


    }
}
