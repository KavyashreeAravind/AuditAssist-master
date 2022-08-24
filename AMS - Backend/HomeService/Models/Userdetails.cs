using System;
using System.Collections.Generic;

namespace HomeService.Models
{
    public partial class Userdetails
    {
        public int Userid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
