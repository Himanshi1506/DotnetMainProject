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
    public class PalletController : ControllerBase
    {
        private IPalletRepository _palletRepository;

        public PalletController(IPalletRepository palletRepository)
        {
            _palletRepository = palletRepository;
        }
        // GET: api/<PalletController>
        [HttpGet]
        public List<PalletDto> Get()
        {
            return _palletRepository.GetAllPallets();
        }

        // GET api/<PalletController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PalletController>
        [HttpPost]
        public IActionResult Post([FromBody] PalletDto palletDto)
        {
            try
            {
                System.Console.WriteLine("1");
                _palletRepository.CreatePallet(palletDto);
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

        // PUT api/<PalletController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PalletController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPut("/AssignNode")]
        public IActionResult AssignNode(int PalletId, int NodeId)
        {
            _palletRepository.AssignNode(PalletId, NodeId);
            return Ok();
        }
    }
}
