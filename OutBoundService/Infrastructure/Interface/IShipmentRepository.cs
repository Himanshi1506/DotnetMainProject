using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Interface
{
    public interface IShipmentRepository
    {
        Task<bool> CreateShipment(ShipmentDto shipmentDto);
        List<ShipmentDto> GetAllShipments();
        void AssignTruck(int ShipmentId, int TruckId);
    }
}
