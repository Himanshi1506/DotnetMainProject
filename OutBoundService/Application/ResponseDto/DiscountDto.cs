using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Application.ResponseDto
{
    public class DiscountDto
    {
        
        public int DiscountId { get; set; }
        public double MaxDiscountAmount { get; set; }
        public int DiscountPercentage { get; set; }
        public double MinOrderAmount { get; set; }
    }
}
