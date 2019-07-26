using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAd.Models
{
    public enum Sex
    {
        Male = 0, Female = 1 // There is only 2 genders
    }
    public class Target
    {
        [ForeignKey("Ad")]
        public int Id { get; set; }
        public string Country { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public Sex Gender { get; set; }
        public Ad Ad { get; set; }
    }
}
