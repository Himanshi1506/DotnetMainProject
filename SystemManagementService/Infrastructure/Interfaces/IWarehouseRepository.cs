using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;

namespace SystemManagementService.Infrastructure.Interfaces
{
    public interface IWarehouseRepository
    {
        Task<bool> CreateWarehouse(WarehouseDto warehouseDto);
        List<WarehouseDto> GetAllWarehouse();
    }
}
