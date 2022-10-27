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
    public class DriverRepository : IDriverRepository
    {
        private OutboundDatabaseContext _outboundDatabaseContext;
        private readonly IMapper _mapper;

        public DriverRepository(IMapper mapper, OutboundDatabaseContext outboundDatabaseContext)
        {
            _mapper = mapper;
            _outboundDatabaseContext = outboundDatabaseContext;
        }

        public async Task<bool> CreateDriver(DriverDto driverDto)
        {
            Driver driver = _mapper.Map<Driver>(driverDto);
            _outboundDatabaseContext.Driver.Add(driver);
            _outboundDatabaseContext.SaveChanges();
            return await Task.FromResult(true);
        }

        public List<DriverDto> GetAllDrivers()
        {
            List<Driver> drivers = _outboundDatabaseContext.Driver.ToList();
            return drivers.Select(driver => _mapper.Map<DriverDto>(driver)).ToList();
        }
    }
}
