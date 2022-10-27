using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Domain.Entities
{
    public class Node
    {
        public int NodeId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Warehouse")]
        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection<Pallet> Pallets { get; set; }
    }
}
