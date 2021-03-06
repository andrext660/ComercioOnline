﻿using ComercioOnline.Dominio.Entidades;
using ComercioOnline.Dominio.Objeto_de_Valor;
using ComercioOnline.Repositorio.Config;
using Microsoft.EntityFrameworkCore;

namespace ComercioOnline.Repositorio.Contexto
{
    public class Context :DbContext
    {
       

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<ItemPedido> ItensPedidos { get; set; }

        public DbSet<FormaPagamento> FormaPagamentos { get; set; }

        public Context(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());

            //Forma de Pagamento

            modelBuilder.Entity<FormaPagamento>().HasData(
              new FormaPagamento()
              {
                  Id = 1,
                  Nome = "Boleto",
                  Descricao = "Forma de Pagamento Boleto"
              },

              new FormaPagamento()
              {
                  Id = 2,
                  Nome = "Cartão de Crédito",
                  Descricao = "Forma de Pagamento Cartão"
              },

              new FormaPagamento()
              {
                  Id = 3,
                  Nome = "Deposito",
                  Descricao = "Forma de Pagamento Depósito"
              });

            //Produtos

            modelBuilder.Entity<Produto>().HasData(
            new Produto()
            {
                Id = 1,
                Nome = "Calabresa",
                Descricao = "Calabresa Defumada",
                Preco = 12
            }
              );

            base.OnModelCreating(modelBuilder);
        }
    }
}
