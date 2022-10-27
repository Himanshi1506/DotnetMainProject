using Microsoft.AspNetCore.Mvc;
using OutBoundService.Application.ResponseDto;
using OutBoundService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OutBoundService.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private IShipmentRepository _shipmentRepository;

        public ShipmentController(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        // GET: api/<ShipmentController>
        [HttpGet]
        public List<ShipmentDto> Get()
        {
            return _shipmentRepository.GetAllShipments();
        }

        // GET api/<ShipmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShipmentController>
        [HttpPost]
        public IActionResult Post([FromBody] ShipmentDto shipmentDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _shipmentRepository.CreateShipment(shipmentDto);
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

        // PUT api/<ShipmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPut("/AssignTruck")]
        public void AssignTruck(int ShipmentId, int TruckId)
        {
            _shipmentRepository.AssignTruck(ShipmentId, TruckId);
        }
    }
}
