using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;
using SystemManagementService.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SystemManagementService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private INodeRepository _nodeRepository;

        public NodeController(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        // GET: api/<NodeController>
        [HttpGet]
        public List<NodeDto> Get()
        {
            return _nodeRepository.GetAllNodes();
        }

        // GET api/<NodeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NodeController>
        [HttpPost]
        public IActionResult Post([FromBody] NodeDto nodeDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _nodeRepository.CreateNode(nodeDto);
                System.Console.WriteLine("6");
                System.Console.WriteLine("customer created");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<NodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPut("/AddWarehouse")]
        public IActionResult AddNode(int WarehouseId, int NodeId)
        {
            _nodeRepository.AddWarehouse(WarehouseId, NodeId);
            return Ok();
        }
    }
}
