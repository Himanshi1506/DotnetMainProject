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
    public class PalletRepository : IPalletRepository
    {
        private SystemManagementDatabaseContext _systemManagementDatabaseContext;
        private readonly IMapper _mapper;
        public PalletRepository(IMapper mapper, SystemManagementDatabaseContext systemManagementDatabaseContext)
        {
            _mapper = mapper;
            _systemManagementDatabaseContext = systemManagementDatabaseContext;
        }
        public async Task<bool> CreatePallet(PalletDto palletDto)
        {
            try
            {
                System.Console.WriteLine("2");
                Pallet pallet = _mapper.Map<Pallet>(palletDto);
                LPN lpn = new LPN();
                pallet.Lpn = lpn;
                System.Console.WriteLine("3");
                _systemManagementDatabaseContext.Pallet.Add(pallet);
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

        public List<PalletDto> GetAllPallets()
        {
            try
            {

                List<Pallet> pallets = _systemManagementDatabaseContext.Pallet.ToList();
                return pallets.Select(pallet => _mapper.Map<PalletDto>(pallet)).ToList();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return new List<PalletDto>();
            }
        }

        public void AssignNode(int PalletId, int NodeId)
        {
            Pallet pallet = _systemManagementDatabaseContext.Pallet.Find(PalletId);
            Node node = _systemManagementDatabaseContext.Node.Find(NodeId);
            pallet.NodeId = NodeId;
            pallet.Node = node;
            _systemManagementDatabaseContext.Pallet.Update(pallet);
            _systemManagementDatabaseContext.SaveChanges();
            node.Pallets.Add(pallet);
            _systemManagementDatabaseContext.Node.Update(node);
            _systemManagementDatabaseContext.SaveChanges();

        }
    }
}
