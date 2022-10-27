using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;
using SystemManagementService.Domain.Entities;
using SystemManagementService.Infrastructure.Interfaces;
using SystemManagementService.Infrastructure.Persistence;

namespace SystemManagementService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private SystemManagementDatabaseContext _systemManagementDatabaseContext;
        private readonly IMapper _mapper;
        public ProductRepository(IMapper mapper, SystemManagementDatabaseContext systemManagementDatabaseContext)
        {
            _mapper = mapper;
            _systemManagementDatabaseContext = systemManagementDatabaseContext;
        }
        public async Task<bool> CreateProduct(ProductDto productDto)
        {
            try
            {
                System.Console.WriteLine("2");
                Product product = _mapper.Map<Product>(productDto);
                System.Console.WriteLine("3");
                _systemManagementDatabaseContext.Product.Add(product);
                System.Console.WriteLine("4");
                _systemManagementDatabaseContext.SaveChanges();
                System.Console.WriteLine("5");
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return false;
            }
        }

        public List<ProductDto> GetAllProducts()
        {
            try
            {

                List<Product> products = _systemManagementDatabaseContext.Product.ToList();
                return products.Select(product => _mapper.Map<ProductDto>(product)).ToList();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return new List<ProductDto>();
            }
        }

        public bool AssignPallet(int ProductId, int PalletId)
        {
            Product product = _systemManagementDatabaseContext.Product.Find(ProductId);
            Pallet pallet = _systemManagementDatabaseContext.Pallet.Find(PalletId);
            if (pallet.PalletQuantity >= pallet.PalletMaxQuantity) return false;
            product.PalletId = PalletId;
            product.Pallet = pallet;
            _systemManagementDatabaseContext.Pallet.Update(pallet);
            _systemManagementDatabaseContext.SaveChanges();
            pallet.Product.Add(product);
            pallet.PalletQuantity++;
            _systemManagementDatabaseContext.Product.Update(product);
            _systemManagementDatabaseContext.SaveChanges();
            return true;
        }
    }
}
