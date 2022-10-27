using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Application.ResponseDto
{
    public class TruckDto
    {
        
        public int TruckId { get; set; }
        public string ModelNumber { get; set; }
        public bool PoliceVerification { get; set; }
        public int? DriverId { get; set; }
        public DriverDto Driver { get; set; }
    }
}
