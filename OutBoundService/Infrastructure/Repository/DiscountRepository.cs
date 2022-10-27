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
    public class DiscountRepository : IDiscountRepository
    {
        private OutboundDatabaseContext _outboundDatabaseContext;
        private readonly IMapper _mapper;

        public DiscountRepository(IMapper mapper, OutboundDatabaseContext outboundDatabaseContext)
        {
            _mapper = mapper;
            _outboundDatabaseContext = outboundDatabaseContext;
        }
        public async Task<bool> CreateDiscount(DiscountDto discountDto)
        {
            Discount discount = _mapper.Map<Discount>(discountDto);
            _outboundDatabaseContext.Discount.Add(discount);
            _outboundDatabaseContext.SaveChanges();
            return await Task.FromResult(true);
        }

        public List<DiscountDto> GetAllDiscounts()
        {
            List<Discount> discounts = _outboundDatabaseContext.Discount.ToList();
            return discounts.Select(discount => _mapper.Map<DiscountDto>(discount)).ToList();
        }
    }
}
