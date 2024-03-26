using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuario.API.Entities;

namespace Usuario.API.Persistence.Repositories
{
    public interface IClienteRepository
    {
        List<Pessoa> ObterTodos();
        Pessoa ObterPorId(int id);
        void Adicionar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        void Deletar(Pessoa pessoa);

        Endereco ObterEnderecoPorId(int id);
        void AdicionarEndereco(Endereco endereco);
    }
}