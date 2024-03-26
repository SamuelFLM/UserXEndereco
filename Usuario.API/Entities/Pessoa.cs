using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuario.API.Entities
{
    public class Pessoa
    {
        public Pessoa(string? nome, int idade, string? cpf)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }
        public int Id { get; private set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public string? Cpf { get; private set; }
        public List<Endereco> Enderecos { get; set; } = null!;

        public void Atualizar(string? nome, int idade, string? cpf)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }
    }
}