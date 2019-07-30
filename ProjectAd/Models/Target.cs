using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAd.Models
{
    public enum Sex
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female // There is only 2 genders
    }
    public class Target
    {
        [ForeignKey("Ad")]
        public int Id { get; set; }
        public string Country { get; set; }
        [Range(1, 200, ErrorMessage = "Only positive values 1-200")]
        public int AgeFrom { get; set; }
        [Range(1, 200, ErrorMessage = "Only positive values 1-200")]
        public int AgeTo { get; set; }
        public Sex Gender { get; set; }
        public Ad Ad { get; set; }
    }
}
