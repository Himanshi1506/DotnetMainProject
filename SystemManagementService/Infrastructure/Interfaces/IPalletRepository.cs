using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;

namespace SystemManagementService.Infrastructure.Interfaces
{
    public interface IPalletRepository
    {
        Task<bool> CreatePallet(PalletDto palletDto);
        List<PalletDto> GetAllPallets();
        void AssignNode(int PalletId, int NodeId);
    }
}
