using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int OrderCount { get; set; }

        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public ICollection<OrderCustomer> OrderCustomers { get; set; }

        public Customer(int CustomerId, string CustomerName)
        {
            this.CustomerId = CustomerId;
            this.CustomerName = CustomerName;
        }

        public override string ToString()
        {
            return this.CustomerId + " " + this.CustomerName + " " + this.DiscountId+" "+this.Discount+" "+this.OrderCustomers;
        }
    }
}
