using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_managemnt.DTOs
{
    public class members
    {
        [Required]
        public int pid { get; set; }

        [Required]
        public int mid { get; set; }
    }
}