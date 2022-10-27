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
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public List<CustomerDto> Get()
        {
            return _customerRepository.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customerDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _customerRepository.CreateCustomer(customerDto);
                System.Console.WriteLine("6");
                System.Console.WriteLine("customer created");
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto customer)
        {
            if (id != customer.CustomerId) return BadRequest();
            _customerRepository.UpdateCustomer(id, customer);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_customerRepository.DeleteCustomer(id) == false) return BadRequest();

            return Ok();
        }

        [HttpPut("/OfferDiscount")]
        public IActionResult OfferDiscount(int CustomerId)
        {
            bool flag = _customerRepository.OfferDiscount(CustomerId);
            if(!flag) return BadRequest();
            return Ok();
        }
    }
}
