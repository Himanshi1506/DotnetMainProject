using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Application.ResponseDto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }
        public int? PalletId { get; set; }
        public PalletDto Pallet { get; set; }
    }
}
