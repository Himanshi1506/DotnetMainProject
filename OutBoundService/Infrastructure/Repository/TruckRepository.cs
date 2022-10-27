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
    public class TruckRepository : ITruckRepository
    {
        private OutboundDatabaseContext _outboundDatabaseContext;
        private readonly IMapper _mapper;

        public TruckRepository(IMapper mapper, OutboundDatabaseContext outboundDatabaseContext)
        {
            _mapper = mapper;
            _outboundDatabaseContext = outboundDatabaseContext;
        }

        public async Task<bool> CreateTruck(TruckDto truckDto)
        {
            Truck truck = _mapper.Map<Truck>(truckDto);
            _outboundDatabaseContext.Truck.Add(truck);
            _outboundDatabaseContext.SaveChanges();
            return await Task.FromResult(true);
        }

        public List<TruckDto> GetAllTrucks()
        {
            List<Truck> truck = _outboundDatabaseContext.Truck.ToList();
            return truck.Select(truck => _mapper.Map<TruckDto>(truck)).ToList();
        }

        public void AssignDriver(int TruckId, int DriverId)
        {
            Truck truck = _outboundDatabaseContext.Truck.Find(TruckId);
            Driver driver = _outboundDatabaseContext.Driver.Find(DriverId);
            truck.DriverId = DriverId;
            truck.Driver = driver;
            _outboundDatabaseContext.Truck.Update(truck);
            _outboundDatabaseContext.SaveChanges();
        }
    }
}
