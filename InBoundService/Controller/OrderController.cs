using InBoundService.Database.Entities;
using InBoundService.Database.Implementation;
using InBoundService.Database.Interface;
using InBoundService.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InBoundService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            return _orderRepository.GetAllOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDto Get(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto order)
        {
            _orderRepository.CreateOrder(order);
            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderDto order)
        {
            if (id != order.OrderId) return BadRequest();
            _orderRepository.UpdateOrder(id, order);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_orderRepository.DeleteOrder(id) == false) return BadRequest();
            
            return Ok();
        }

        [HttpPut("{id}/VerifyOrder")]
        public string VerifyOrder(int id)
        {
            if(_orderRepository.IsVerify(id))
            {
                return "already verified";
            }
            _orderRepository.VerifyOrder(id);
            return "verification done";
        }

        [HttpPut("{id}/AcceptOrRejectOrder")]
        public string AcceptOrRejectOrder(int id)
        {
            if (_orderRepository.IsVerify(id))
            {
                _orderRepository.AcceptOrder(id);
                return "order Accepted";
            }
            _orderRepository.RejectOrder(id);
            return "order rejected";
        }
    }
}
