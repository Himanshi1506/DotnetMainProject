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
    public class DiscountController : ControllerBase
    {
        private IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        // GET: api/<DiscountController>
        [HttpGet]
        public IEnumerable<DiscountDto> Get()
        {
            return _discountRepository.GetAllDiscounts();
        }

        // GET api/<DiscountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DiscountController>
        [HttpPost]
        public IActionResult Post([FromBody] DiscountDto discountDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _discountRepository.CreateDiscount(discountDto);
                System.Console.WriteLine("6");
                System.Console.WriteLine("Discount created");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<DiscountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DiscountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
