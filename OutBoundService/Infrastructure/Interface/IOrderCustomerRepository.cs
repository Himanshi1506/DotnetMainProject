using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Interface
{
    public interface IOrderCustomerRepository
    {
        Task<bool> CreateNewCutomerOrder(OrderCustomerDto orderCustomerDto, int CustomerId);
        List<OrderCustomerDto> GetAllOrdersofCustomers();
        void CreateShipment(int orderId);
        void ChangeShipmentStatus(int id);
    }
}
