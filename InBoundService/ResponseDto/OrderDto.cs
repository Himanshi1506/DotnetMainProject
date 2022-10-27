using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InBoundService.ResponseDto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public String OrderType { get; set; }
        public int Quantity { get; set; }
        public bool IsVeriied { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}

