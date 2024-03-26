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
    [Route("api/cliente")]
    public class PessoaController : ControllerBase
    {
        private readonly IClienteRepository _cliente;

        public PessoaController(IClienteRepository cliente) => _cliente = cliente;


        [HttpGet]
        public IActionResult ObterTodos()
        {
            var clientes = _cliente.ObterTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _cliente.ObterPorId(id);

            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Adicionar(AdicionarPessoaInputModel model)
        {
            Pessoa pessoa = new Pessoa(model.Nome, model.Idade, model.Cpf);

            _cliente.Adicionar(pessoa);

            return CreatedAtAction(nameof(ObterPorId), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarPessoaInputModel model)
        {
            var cliente = _cliente.ObterPorId(id);

            if (cliente is null)
                return NotFound();

            cliente.Atualizar(model.Nome, model.Idade, model.Cpf);

            _cliente.Atualizar(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var cliente = _cliente.ObterPorId(id);

            if (cliente is null)
                return NotFound();

            _cliente.Deletar(cliente);

            return NoContent();
        }
    }
}