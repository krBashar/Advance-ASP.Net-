using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_managemnt.DTOs
{
    public class user
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string role { get; set; }
    }
}