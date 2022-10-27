using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;

namespace SystemManagementService.Infrastructure.Interfaces
{
    public interface INodeRepository
    {
        Task<bool> CreateNode(NodeDto nodeDto);
        List<NodeDto> GetAllNodes();
        void AddWarehouse(int WarehouseId, int NodeId);
    }
}
