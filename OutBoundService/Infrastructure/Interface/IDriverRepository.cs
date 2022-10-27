using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Interface
{
    public interface IDriverRepository
    {
        Task<bool> CreateDriver(DriverDto driverDto);
        List<DriverDto> GetAllDrivers();
    }
}
