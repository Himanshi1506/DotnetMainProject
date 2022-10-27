using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Application.ResponseDto
{
    public class ShipmentDto
    {
        
        public int ShipmentId { get; set; }
        public ShipmentStatus ShipStatus { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int? TruckId { get; set; }
        public TruckDto Truck { get; set; }
    }
}
