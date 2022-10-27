using AutoMapper;
using OutBoundService.Application.ResponseDto;
using OutBoundService.Domain.Entities;
using OutBoundService.Infrastructure.Interface;
using OutBoundService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        private OutboundDatabaseContext _outboundDatabaseContext;
        private readonly IMapper _mapper;

        public ShipmentRepository(IMapper mapper, OutboundDatabaseContext outboundDatabaseContext)
        {
            _mapper = mapper;
            _outboundDatabaseContext = outboundDatabaseContext;
        }

        public async Task<bool> CreateShipment(ShipmentDto shipmentDto)
        {
            Shipment shipment = _mapper.Map<Shipment>(shipmentDto);
            _outboundDatabaseContext.Shipment.Add(shipment);
            _outboundDatabaseContext.SaveChanges();
            return await Task.FromResult(true);
        }

        public List<ShipmentDto> GetAllShipments()
        {
            List<Shipment> shipment = _outboundDatabaseContext.Shipment.ToList();
            return shipment.Select(shipment => _mapper.Map<ShipmentDto>(shipment)).ToList();
        }

        public void AssignTruck(int ShipmentId, int TruckId)
        {
            Truck truck = _outboundDatabaseContext.Truck.Find(TruckId);
            Shipment shipment = _outboundDatabaseContext.Shipment.Find(ShipmentId);
            shipment.TruckId = truck.TruckId;
            shipment.Truck = truck;
            _outboundDatabaseContext.Shipment.Update(shipment);
            _outboundDatabaseContext.SaveChanges();
        }
    }
}
