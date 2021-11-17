using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReCommerce.Models;

namespace ReCommerce.Dados
{
    public class ReCommerceContext : DbContext
    {
        public ReCommerceContext(DbContextOptions<ReCommerceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>()
                .HasMany(us => us.Trocas).WithOne();

            modelBuilder.Entity<Troca>().HasKey(t => t.Id);
          
            modelBuilder.Entity<Troca>()
                .HasMany(tr => tr.ProdutosUsuarioDois).WithOne();
            modelBuilder.Entity<Troca>()
                .HasMany(tr => tr.ProdutosUsuarioUm).WithOne();

            modelBuilder.Entity<Troca>()
                .HasOne(tr => tr.UsuarioUm);
            modelBuilder.Entity<Troca>()
               .HasOne(tr => tr.UsuarioDois);

            modelBuilder.Entity<UsuarioProduto>().HasKey(up => new { up.UsuarioId, up.ProdutoId });

            modelBuilder.Entity<UsuarioEndereco>().HasKey(up => new { up.UsuarioId, up.EnderecoId });

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Produto>()
                .HasMany(pr => pr.Trocas).WithOne();
        }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Troca> Troca { get; set; }

        public DbSet<UsuarioProduto> UsuarioProduto { get; set; }

        public DbSet<UsuarioEndereco> UsuarioEndereco { get; set; }

    }
}
