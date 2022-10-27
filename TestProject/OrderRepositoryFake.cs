using InBoundService.Database.Entities;
using InBoundService.Database.Interface;
using InBoundService.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class OrderRepositoryFake : IOrderRepository
    {
        private readonly List<OrderDto> _orders;
        public OrderRepositoryFake()
        {
            _orders = new List<OrderDto>()
            {
                new OrderDto() { OrderId = 1,
                    OrderType = "Phone", Quantity=100 },
                new OrderDto() { OrderId = 2,
                    OrderType = "Laptop", Quantity=25 },
                new OrderDto() { OrderId = 3,
                    OrderType = "Charger", Quantity=80 }
            };
        }

        public void AcceptOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateOrder(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDto> GetAllItems()
        {
            return _orders;
        }

        public List<OrderDto> GetAllOrders()
        {
            return _orders;
        }


        public OrderDto GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsVerify(int id)
        {
            throw new NotImplementedException();
        }

        public void RejectOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(int id, OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public void VerifyOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
