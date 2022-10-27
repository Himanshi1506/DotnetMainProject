using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;
using SystemManagementService.Domain.Entities;
using SystemManagementService.Infrastructure.Interfaces;
using SystemManagementService.Infrastructure.Persistence;

namespace SystemManagementService.Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private SystemManagementDatabaseContext _systemManagementDatabaseContext;
        private readonly IMapper _mapper;
        public WarehouseRepository(IMapper mapper, SystemManagementDatabaseContext systemManagementDatabaseContext)
        {
            _mapper = mapper;
            _systemManagementDatabaseContext = systemManagementDatabaseContext;
        }

        public async Task<bool> CreateWarehouse(WarehouseDto warehouseDto)
        {
            try
            {
                System.Console.WriteLine("2");
                Warehouse warehouse = _mapper.Map<Warehouse>(warehouseDto);
                System.Console.WriteLine("3");
                _systemManagementDatabaseContext.Warehouse.Add(warehouse);
                System.Console.WriteLine("4");
                _systemManagementDatabaseContext.SaveChanges();
                System.Console.WriteLine("5");
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return false;
            }
        }

        public List<WarehouseDto> GetAllWarehouse()
        {
            try
            {

                List<Warehouse> warehouses = _systemManagementDatabaseContext.Warehouse.ToList();
                return warehouses.Select(warehouse => _mapper.Map<WarehouseDto>(warehouse)).ToList();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return new List<WarehouseDto>();
            }
        }
    }
}
