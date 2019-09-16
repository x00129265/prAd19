using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAd.Models
{

    public class Payment
    {   
        [Range(1, 1000, ErrorMessage = "Enter positive number of credits you want to buy (1-1000)")]
        public int Qty { get; set; }
        public double Price { get; set; } = 0;

        //private int Id { get; set; }
        //private Ad Ad { get; set; }
        //private ApplicationUser User { get; set; }
    }
}
