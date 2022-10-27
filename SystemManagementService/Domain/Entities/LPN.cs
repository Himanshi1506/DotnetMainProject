using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagementService.Domain.Entities
{
    public class LPN
    {
        [Key]
        public int LpnNo { get; set; }
    }
}
