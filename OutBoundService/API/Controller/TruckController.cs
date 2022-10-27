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
    public class TruckController : ControllerBase
    {
        private ITruckRepository _truckRepository;

        public TruckController(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        // GET: api/<TruckController>
        [HttpGet]
        public List<TruckDto> Get()
        {
            return _truckRepository.GetAllTrucks();
        }

        // GET api/<TruckController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TruckController>
        [HttpPost]
        public IActionResult Post([FromBody] TruckDto truckDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _truckRepository.CreateTruck(truckDto);
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

        // PUT api/<TruckController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TruckController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPut("/AssignDriver")]
        public IActionResult AssignDriver(int TruckId, int DriverId)
        {
            _truckRepository.AssignDriver(TruckId, DriverId);
            return Ok();
        }

    }
}
