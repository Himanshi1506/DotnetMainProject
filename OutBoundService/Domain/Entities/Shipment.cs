using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

public enum ShipmentStatus
{
    ReadyForShipment,
    Shipped,
    OutForDelivery,
    Rejected
}
namespace OutBoundService.Domain.Entities
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public ShipmentStatus ShipStatus { get; set; }
        public DateTime ShipmentDate { get; set; }

        public ICollection<OrderCustomer> Orders { get; set; }

        [ForeignKey("Truck")]
        public int? TruckId { get; set; }
        public Truck Truck { get; set; }

        public Shipment(ShipmentStatus ShipStatus, DateTime ShipmentDate)
        {
            this.ShipStatus = ShipStatus;
            this.ShipmentDate = ShipmentDate;
        }

    }
}
