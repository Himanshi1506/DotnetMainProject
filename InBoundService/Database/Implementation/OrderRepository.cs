using AutoMapper;
using InBoundService.Database.Entities;
using InBoundService.Database.Interface;
using InBoundService.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InBoundService.Database.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private InboundDatabaseContext _inboundDatabaseContext;
        private readonly IMapper _mapper;

        public OrderRepository(IMapper mapper, InboundDatabaseContext inboundDatabaseContext)
        {
            _mapper = mapper;
            _inboundDatabaseContext = inboundDatabaseContext;
        }
        public async Task<bool> CreateOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            _inboundDatabaseContext.Orders.Add(order);
            _inboundDatabaseContext.SaveChanges();
            return await Task.FromResult(true);
        }

        public List<OrderDto> GetAllOrders()
        {
            List<Order> orders = _inboundDatabaseContext.Orders.ToList();
            return orders.Select(order => _mapper.Map<OrderDto>(order)).ToList();
        }

        public OrderDto GetOrderById(int id)
        {
            Order order= _inboundDatabaseContext.Orders.Find(id);
            return _mapper.Map<OrderDto>(order);
        }

        public bool DeleteOrder(int id)
        {
            Order order = _inboundDatabaseContext.Orders.Find(id);
            if (order == null) return false;
             
            _inboundDatabaseContext.Orders.Remove(order);
            _inboundDatabaseContext.SaveChanges();
            return true;
        }

        public void UpdateOrder(int id ,OrderDto orderDto)
        {
            Order order= _mapper.Map<Order>(orderDto);
            _inboundDatabaseContext.Orders.Update(order);
            _inboundDatabaseContext.SaveChanges();
        }

        public bool IsVerify(int id)
        {
            Order order = _inboundDatabaseContext.Orders.Find(id);
            return order.IsVeriied;
        }

        public void VerifyOrder(int id)
        {
            Order order = _inboundDatabaseContext.Orders.Find(id);
            order.IsVeriied=true;
            _inboundDatabaseContext.Orders.Update(order);
            _inboundDatabaseContext.SaveChanges();
        }

        public void AcceptOrder(int id)
        {
            Order order = _inboundDatabaseContext.Orders.Find(id);
            order.OrderStatus = OrderStatus.Accept;
            _inboundDatabaseContext.Orders.Update(order);
            _inboundDatabaseContext.SaveChanges();
        }

        public void RejectOrder(int id)
        {
            Order order = _inboundDatabaseContext.Orders.Find(id);
            order.OrderStatus = OrderStatus.Reject;
            _inboundDatabaseContext.Orders.Update(order);
            _inboundDatabaseContext.SaveChanges();
        }
    }
}
