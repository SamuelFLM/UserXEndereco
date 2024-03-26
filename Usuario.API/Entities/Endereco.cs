using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuario.API.Entities
{
    public class Endereco
    {
        public Endereco(string? rua, string? bairro, int numero, int idPessoa)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            IdPessoa = idPessoa;
        }
        public int Id { get; private set; }
        public string? Rua { get; private set; }
        public string? Bairro { get; private set; }
        public int Numero { get; private set; }
        public int IdPessoa { get; private set; }
    }
}