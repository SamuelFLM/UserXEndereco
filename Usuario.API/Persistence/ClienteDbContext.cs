using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Usuario.API.Entities;

namespace Usuario.API.Persistence
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Pessoa>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.Enderecos)
                .WithOne()
                .HasForeignKey(ed => ed.IdPessoa);
            });

            model.Entity<Endereco>(e =>
            {
                e.HasKey(ed => ed.Id);
            });
        }
    }
}