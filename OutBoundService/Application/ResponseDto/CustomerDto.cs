using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Application.ResponseDto
{
    public class CustomerDto
    {
        
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int OrderCount { get; set; }
        public ICollection<OrderCustomerDto> OrderCustomers { get; set; }
        public int? DiscountId { get; set; }

        public DiscountDto discount { get; set; }
    }
}
