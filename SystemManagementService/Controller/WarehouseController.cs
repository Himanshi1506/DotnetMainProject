using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Application.ResponseDto;
using SystemManagementService.Infrastructure.Interfaces;
using SystemManagementService.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SystemManagementService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        // GET: api/<WarehouseController>
        [HttpGet]
        public List<WarehouseDto> Get()
        {
            return _warehouseRepository.GetAllWarehouse();
        }

        // GET api/<WarehouseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WarehouseController>
        [HttpPost]
        public IActionResult Post([FromBody] WarehouseDto warehouseDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _warehouseRepository.CreateWarehouse(warehouseDto);
                System.Console.WriteLine("6");
                System.Console.WriteLine("Warehouse created");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<WarehouseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WarehouseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
