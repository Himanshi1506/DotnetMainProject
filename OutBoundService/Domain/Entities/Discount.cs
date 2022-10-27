using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Domain.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public double MaxDiscountAmount { get; set; }
        public int DiscountPercentage { get; set; }
        public double MinOrderAmount { get; set; }
        

    }
}
