using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Usuario.API.Entities;

namespace Usuario.API.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;
        public ClienteRepository(ClienteDbContext context) => _context = context;

        public void Adicionar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public void Atualizar(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }

        public void Deletar(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }

        public Endereco ObterEnderecoPorId(int id)
        {
            var endereco = _context.Enderecos.SingleOrDefault(x => x.Id == id);
            return endereco!;
        }

        public Pessoa ObterPorId(int id)
        {
            var pessoa = _context.Pessoas.SingleOrDefault(x => x.Id == id);
            return pessoa!;
        }

        public List<Pessoa> ObterTodos()
        {
            var pessoas = _context.Pessoas.AsNoTracking().Include(x => x.Enderecos).ToList();
            return pessoas!;
        }
    }
}