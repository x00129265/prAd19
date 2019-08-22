using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAd.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public string Link { get; set; }
        public double Credit { get; set; } = 0;
        public ApplicationUser User { get; set; }
    }
}
