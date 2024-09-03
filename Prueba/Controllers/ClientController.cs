using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var clients = _clientService.GetAll();
            return clients == null ? NotFound() : Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var client = _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client newClient)
        {
            if (newClient == null)
            {
                return NotFound();
            }
            _clientService.Add(newClient);
            return CreatedAtAction(nameof(Get), new { id = newClient.id }, newClient);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client newClient)
        {
            var client = _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            _clientService.Update(newClient);
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var client = _clientService.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            _clientService.Delete(id);
            return Ok();
        }

        //[HttpGet(Name = "Prueba")]
        //public IActionResult Prueba()
        //{
        //    return Ok("Ok");
        //}

        //[HttpGet]
        //[Route("list")]
        //public IActionResult listarCliente() {
        //    List<Client> clients = new List<Client> {
        //        new Client
        //        {
        //            id = "1",
        //            name = "Alex",
        //            age = "22"
        //        }
        //    };

        //    return clients == null ? NotFound() : Ok(clients) ;
        //}
    }
}
