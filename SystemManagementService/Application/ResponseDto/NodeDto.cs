using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Application.ResponseDto
{
    public class NodeDto
    {
        public int NodeId { get; set; }
        public string Name { get; set; }
        public int? WarehouseId { get; set; }
        public WarehouseDto Warehouse { get; set; }
    }
}
