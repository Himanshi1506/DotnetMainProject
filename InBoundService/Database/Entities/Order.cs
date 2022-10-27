using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InBoundService.Database.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderType { get; set; }
        public int Quantity { get; set; }
        public bool IsVeriied { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}


public enum OrderStatus
{
    Accept,
    Reject
}

