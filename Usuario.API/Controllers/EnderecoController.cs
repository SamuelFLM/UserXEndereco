using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Usuario.API.Entities;
using Usuario.API.Models;
using Usuario.API.Persistence.Repositories;

namespace Usuario.API.Controllers
{
    [ApiController]
    [Route("api/cliente/{id}/endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IClienteRepository _cliente;

        public EnderecoController(IClienteRepository cliente) => _cliente = cliente;



        [HttpGet]
        public IActionResult ObterTodos(int id)
        {
            var endereco = _cliente.ObterEnderecoPorId(id);
            if (endereco is null)
                return NotFound();
            return Ok(endereco);
        }

        [HttpPost]
        public IActionResult AdicionarEndereco(int id, AdicionarEnderecoInputModel model)
        {

            Endereco endereco = new Endereco(model.Rua, model.Bairro, model.Numero, id);

            _cliente.AdicionarEndereco(endereco);

            return NoContent();
        }
    }
}