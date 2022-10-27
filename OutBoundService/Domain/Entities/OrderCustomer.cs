
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Domain.Entities
{
    public class OrderCustomer
    {
        [Key]
        public int OrderCustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Shipment")]
        public int? ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public override string ToString()
        {
            return this.OrderCustomerId + " " + this.DeliveryAddress + " " + this.CustomerId + " " + this.Customer;
        }
    }
}
