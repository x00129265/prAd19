using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAd.Models
{
    
    public class Payment
    {
        [ForeignKey("Ad")]
        private int Id { get; set; }
        private Ad Ad { get; set; }
        public int Qty
        {
            get
            {
                return Qty;
            }
            set
            {
                Qty = value;
                Price = PricePerItem * value;
            }
        }
        public double Price { get; set; } = 0;
        public double PricePerItem { get; } = 2.5;

    }
}
