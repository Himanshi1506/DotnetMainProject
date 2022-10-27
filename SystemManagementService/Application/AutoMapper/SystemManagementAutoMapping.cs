using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;
using SystemManagementService.Domain.Entities;

namespace SystemManagementService.Application.AutoMapper
{
    public class SystemManagementAutoMapping : Profile
    {
        public SystemManagementAutoMapping()
        {
            CreateMap<Node,NodeDto>();
            CreateMap<NodeDto, Node>();
            CreateMap<Pallet, PalletDto>();
            CreateMap<PalletDto, Pallet>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<WarehouseDto, Warehouse>();
        }
    }
}
