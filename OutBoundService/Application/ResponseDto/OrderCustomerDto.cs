using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Application.ResponseDto
{
    public class OrderCustomerDto
    {
        
        public int OrderCustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }
        public int? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int? ShipmentId { get; set; }
        public ShipmentDto Shipment { get; set; }

    }
}
