using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }

        [ForeignKey("Pallet")]
        public int? PalletId { get; set; }
        public Pallet Pallet { get; set; }
    }
}
