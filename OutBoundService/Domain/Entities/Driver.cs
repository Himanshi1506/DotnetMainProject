using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Domain.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }

        public Truck Truck { get; set; }

    }
}
