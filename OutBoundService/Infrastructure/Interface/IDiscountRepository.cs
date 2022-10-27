using OutBoundService.Application.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutBoundService.Infrastructure.Interface
{
    public interface IDiscountRepository
    {
        Task<bool> CreateDiscount(DiscountDto discountDto);
        List<DiscountDto> GetAllDiscounts();
    }
}
