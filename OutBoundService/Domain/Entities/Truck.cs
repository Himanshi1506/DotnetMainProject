using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Domain.Entities
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string ModelNumber { get; set; }
        public bool PoliceVerification { get; set; }
        [ForeignKey("Driver")]
        public int? DriverId { get; set; }
        public Driver Driver { get; set; }

        public ICollection<Shipment> Shipment { get; set; }
    }
}
