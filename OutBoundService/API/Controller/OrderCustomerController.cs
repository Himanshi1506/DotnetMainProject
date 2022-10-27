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
    public class OrderCustomerController : ControllerBase
    {
        private IOrderCustomerRepository _orderCustomerRepository;

        public OrderCustomerController(IOrderCustomerRepository orderCustomerRepository)
        {
            _orderCustomerRepository = orderCustomerRepository;
        }

        // GET: api/<OrderCustomerController>
        [HttpGet]
        public List<OrderCustomerDto> Get()
        {
            System.Console.WriteLine("Get 1");
            return _orderCustomerRepository.GetAllOrdersofCustomers();
        }

        // GET api/<OrderCustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderCustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderCustomerDto orderCustomerDto, int CustomerId)
        {
            try
            {
                System.Console.WriteLine("Post");
                System.Console.WriteLine("1");
                _orderCustomerRepository.CreateNewCutomerOrder(orderCustomerDto, CustomerId);
                System.Console.WriteLine("4");
                System.Console.WriteLine("order created");
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello World!" + e);
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<OrderCustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderCustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPut("/ReadyForShipment")]
        public IActionResult ReadyForShipment(int OrderId)
        {
            _orderCustomerRepository.CreateShipment(OrderId);
            return Ok();
        }

        [HttpPut("/ChangeShipmentStatus")]
        public IActionResult ChangeShipmentStatus(int ShipmentId)
        {
            _orderCustomerRepository.ChangeShipmentStatus(ShipmentId);
            return Ok();
        }
        
    }
}
