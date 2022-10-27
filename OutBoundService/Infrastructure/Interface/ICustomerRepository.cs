using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Interface
{
    public interface ICustomerRepository
    {
        Task<bool> CreateCustomer(CustomerDto customerDto);
        List<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int id);
        bool DeleteCustomer(int id);
        void UpdateCustomer(int id, CustomerDto customerDto);

        bool OfferDiscount(int id);
    }
}
