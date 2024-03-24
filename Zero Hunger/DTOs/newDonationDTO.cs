using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Hunger.DTOs
{
    public class newDonationDTO
    {
        [Required]
        public int uid { get; set; }
        [Required]
        public string quantity { get; set; }
        [Required]
        public System.TimeSpan maxtime { get; set; }
        [Required]
        public string address { get; set; }
        public string status { get; set; }

    }
}