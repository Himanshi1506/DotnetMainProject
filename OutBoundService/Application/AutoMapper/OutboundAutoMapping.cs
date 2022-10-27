using AutoMapper;
using OutBoundService.Application.ResponseDto;
using OutBoundService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Application.AutoMapper
{
    public class OutboundAutoMapping :Profile

    {
        public OutboundAutoMapping()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto,Customer>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>();
            CreateMap<Driver, DriverDto>();
            CreateMap<DriverDto, Driver>();
            CreateMap<Shipment, ShipmentDto>();
            CreateMap<ShipmentDto, Shipment>();
            CreateMap<Truck, TruckDto>();
            CreateMap<TruckDto, Truck>();
            CreateMap<OrderCustomer, OrderCustomerDto>();
            CreateMap<OrderCustomerDto, OrderCustomer>();
        }
    }
}
