using InBoundService.Database.Entities;
using InBoundService.ResponseDto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InBoundService.Database.Interface
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrder(OrderDto order);
        List<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int id);
        bool DeleteOrder(int id);
        void UpdateOrder(int id,OrderDto orderDto);
        public void VerifyOrder(int id);

        public bool IsVerify(int id);
        void AcceptOrder(int id);
        void RejectOrder(int id);


    }
}
