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
    public class NodeRepository : INodeRepository
    {
        private SystemManagementDatabaseContext _systemManagementDatabaseContext;
        private readonly IMapper _mapper;
        public NodeRepository(IMapper mapper, SystemManagementDatabaseContext systemManagementDatabaseContext)
        {
            _mapper = mapper;
            _systemManagementDatabaseContext = systemManagementDatabaseContext;
        }
        public async Task<bool> CreateNode(NodeDto nodeDto)
        {
            try
            {
                System.Console.WriteLine("2");
                Node node = _mapper.Map<Node>(nodeDto);
                System.Console.WriteLine("3");
                _systemManagementDatabaseContext.Node.Add(node);
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

        public List<NodeDto> GetAllNodes()
        {
            try
            {

                List<Node> nodes = _systemManagementDatabaseContext.Node.ToList();
                return nodes.Select(node => _mapper.Map<NodeDto>(node)).ToList();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return new List<NodeDto>();
            }
        }

        public void AddWarehouse(int WarehouseId, int NodeId)
        {
            Warehouse warehouse = _systemManagementDatabaseContext.Warehouse.Find(WarehouseId);
            Node node = _systemManagementDatabaseContext.Node.Find(NodeId);
            node.WarehouseId = WarehouseId;
            node.Warehouse = warehouse;
            _systemManagementDatabaseContext.Node.Update(node);
            _systemManagementDatabaseContext.SaveChanges();
            warehouse.Nodes.Add(node);
            _systemManagementDatabaseContext.Warehouse.Update(warehouse);
            _systemManagementDatabaseContext.SaveChanges();
            
        }
    }
}
