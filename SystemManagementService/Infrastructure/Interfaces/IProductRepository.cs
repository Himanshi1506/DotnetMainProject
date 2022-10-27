using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;

namespace SystemManagementService.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> CreateProduct(ProductDto productDto);
        List<ProductDto> GetAllProducts();
        bool AssignPallet(int ProductId, int PalletId);
    }
}
