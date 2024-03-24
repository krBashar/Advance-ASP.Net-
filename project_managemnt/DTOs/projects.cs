using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_managemnt.DTOs
{
    public class projects
    {
        [Required]
        public string pname { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public System.DateTime deadline { get; set; }

        [Required]
        public string status { get; set; }

        [Required]
        public int cid { get; set; }
    }
}