using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Domain.Entities
{
    public class Pallet
    {
        public int PalletId { get; set; }
        public string PalletName { get; set; }
        public int PalletQuantity { get; set; }
        public int PalletMaxQuantity { get; set; }
        [ForeignKey("Node")]
        public int? NodeId { get; set; }
        public Node Node { get; set; }
        [ForeignKey("Lpn")]
        public int? LpnId { get; set; }
        public LPN Lpn { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
