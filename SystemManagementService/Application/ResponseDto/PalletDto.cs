using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Application.ResponseDto
{
    public class PalletDto
    {
        public int PalletId { get; set; }
        public string PalletName { get; set; }
        public int PalletQuantity { get; set; }
        public int PalletMaxQuantity { get; set; }
        public int? NodeId { get; set; }
        public NodeDto Node { get; set; }
        public int? LpnId { get; set; }
        public LpnDto Lpn { get; set; }
    }
}
