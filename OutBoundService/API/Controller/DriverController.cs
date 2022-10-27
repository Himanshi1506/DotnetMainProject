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
    public class DriverController : ControllerBase
    {
        private IDriverRepository _driverRepository;

        public DriverController(IDriverRepository customerRepository)
        {
            _driverRepository = customerRepository;
        }

        // GET: api/<DriverController>
        [HttpGet]
        public List<DriverDto> Get()
        {
            return _driverRepository.GetAllDrivers();
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriverController>
        [HttpPost]
        public IActionResult Post([FromBody] DriverDto driverDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _driverRepository.CreateDriver(driverDto);
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

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
