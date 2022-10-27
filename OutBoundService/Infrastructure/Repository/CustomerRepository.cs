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
    public class CustomerRepository : ICustomerRepository
    {
        private OutboundDatabaseContext _outboundDatabaseContext;
        private readonly IMapper _mapper;

        public CustomerRepository(IMapper mapper, OutboundDatabaseContext outboundDatabaseContext)
        {
            _mapper = mapper;
            _outboundDatabaseContext = outboundDatabaseContext;
        }

        public async Task<bool> CreateCustomer(CustomerDto customerDto)
        {
            try
            {
                System.Console.WriteLine("2");
                Customer customer = _mapper.Map<Customer>(customerDto);
                System.Console.WriteLine("3");
                _outboundDatabaseContext.Customers.Add(customer);
                System.Console.WriteLine("4");
                _outboundDatabaseContext.SaveChanges();
                System.Console.WriteLine("5");
                return await Task.FromResult(true);
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return false;
            }
        }

        public List<CustomerDto> GetAllCustomers()
        {
            try
            {
                
                List<Customer> customers = _outboundDatabaseContext.Customers.ToList();
                return customers.Select(customer => _mapper.Map<CustomerDto>(customer)).ToList();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return new List<CustomerDto>();
            }
        }

        public CustomerDto GetCustomerById(int id)
        {
            Customer customer = _outboundDatabaseContext.Customers.Find(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public bool DeleteCustomer(int id)
        {
            Customer customer = _outboundDatabaseContext.Customers.Find(id);
            if (customer == null) return false;

            _outboundDatabaseContext.Customers.Remove(customer);
            _outboundDatabaseContext.SaveChanges();
            return true;
        }

        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            _outboundDatabaseContext.Customers.Update(customer);
            _outboundDatabaseContext.SaveChanges();
        }

        public bool OfferDiscount(int id)
        {
            Customer customer = _outboundDatabaseContext.Customers.Find(id);
            if(customer.OrderCount>10)
            {
                Discount discount= _outboundDatabaseContext.Discount.Find(1);
                customer.Discount = discount;
                _outboundDatabaseContext.Customers.Update(customer);
                _outboundDatabaseContext.SaveChanges();
                return true; 
            }
            return false;
        }
    }
}
