using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Interface
{
    public interface ITruckRepository
    {
        Task<bool> CreateTruck(TruckDto truckDto);
        List<TruckDto> GetAllTrucks();
        void AssignDriver(int TruckId, int DriverId);
    }
}
