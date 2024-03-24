using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string password { get; set; }

        [Required]
        public string email { get; set; }
    }
}