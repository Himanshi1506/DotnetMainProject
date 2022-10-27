using AutoMapper;
using OutBoundService.Application.ResponseDto;
using OutBoundService.Domain.Entities;
using OutBoundService.Infrastructure.Interface;
using OutBoundService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Repository
{
    public class OrderCustomerRepository : IOrderCustomerRepository
    {
        private OutboundDatabaseContext _outboundDatabaseContext;
        private readonly IMapper _mapper;

        public OrderCustomerRepository(IMapper mapper, OutboundDatabaseContext outboundDatabaseContext)
        {
            _mapper = mapper;
            _outboundDatabaseContext = outboundDatabaseContext;
        }
        public async Task<bool> CreateNewCutomerOrder(OrderCustomerDto orderCustomerDto,int CustomerId)
        {
            Customer customer = _outboundDatabaseContext.Customers.Find(CustomerId);
            System.Console.WriteLine(customer.ToString());
            OrderCustomer orderCustomer = _mapper.Map<OrderCustomer>(orderCustomerDto);
            orderCustomer.CustomerId = CustomerId;
            orderCustomer.Customer = customer;
            System.Console.WriteLine(orderCustomer.ToString());
            _outboundDatabaseContext.OrderCustomer.Add(orderCustomer);
            _outboundDatabaseContext.SaveChanges();
            System.Console.WriteLine(orderCustomer.ToString());
            customer.OrderCustomers.Add(orderCustomer);
            _outboundDatabaseContext.Customers.Update(customer);
            System.Console.WriteLine(customer.ToString());
            _outboundDatabaseContext.SaveChanges();
            System.Console.WriteLine(orderCustomer);
            System.Console.WriteLine(customer.ToString());
            return await Task.FromResult(true);
        }

        public List<OrderCustomerDto> GetAllOrdersofCustomers()
        {
            System.Console.WriteLine("111");
            try
            {
                System.Console.WriteLine("2");
                List<OrderCustomer> orderCustomer = _outboundDatabaseContext.OrderCustomer.ToList();
                System.Console.WriteLine(orderCustomer[0].ToString());
                System.Console.WriteLine("3");
                return orderCustomer.Select(orderCustomer => _mapper.Map<OrderCustomerDto>(orderCustomer)).ToList();
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Order Customer get " + e);
                return new List<OrderCustomerDto>();
            }
        }

        public void CreateShipment(int orderId)
        {
            OrderCustomer order = _outboundDatabaseContext.OrderCustomer.Find(orderId);
            Shipment shipment = new Shipment(ShipmentStatus.ReadyForShipment, DateTime.Now);
            _outboundDatabaseContext.Shipment.Add(shipment);
            _outboundDatabaseContext.SaveChanges();
            order.Shipment = shipment;
            _outboundDatabaseContext.OrderCustomer.Update(order);
            _outboundDatabaseContext.SaveChanges();
        }

        public void ChangeShipmentStatus(int id)
        {
            Shipment shipment = _outboundDatabaseContext.Shipment.Find(id);
            if(shipment.ShipStatus== ShipmentStatus.ReadyForShipment)
            {
                shipment.ShipStatus = ShipmentStatus.Shipped;
                _outboundDatabaseContext.Shipment.Update(shipment);
                _outboundDatabaseContext.SaveChanges();
            }
            else if (shipment.ShipStatus == ShipmentStatus.Shipped)
            {
                shipment.ShipStatus = ShipmentStatus.OutForDelivery;
                _outboundDatabaseContext.Shipment.Update(shipment);
                _outboundDatabaseContext.SaveChanges();
            }
        }
    }
}
