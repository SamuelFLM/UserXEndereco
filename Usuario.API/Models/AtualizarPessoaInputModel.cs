using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuario.API.Models
{
    public record AtualizarPessoaInputModel(string? Nome, int Idade, string? Cpf)
    {

    }
}