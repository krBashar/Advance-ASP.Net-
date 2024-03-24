using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.EF;


namespace Zero_Hunger.Models
{
    public class OrderViewModel
    {
        public List<order> Orders { get; set; }
        public List<user> Users { get; set; }

        public List<distribution> Distributions { get; set; }
    }
}