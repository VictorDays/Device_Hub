using Device_Hub.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Device_Hub.App_Data
{
    public class DeviceHubContext : IdentityDbContext<ApplicationUser>
    {
        public DeviceHubContext() : base("name=DeviceHubContext")
        {
        }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<Garantia> Garantias { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public static DeviceHubContext Create()
        {
            return new DeviceHubContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remover a convenção de pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Configurações para a classe Ativo
            modelBuilder.Entity<Ativo>()
                .HasRequired(a => a.Responsavel)
                .WithMany(f => f.Ativos)
                .HasForeignKey(a => a.ResponsavelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ativo>()
                .HasRequired(a => a.Departamento)
                .WithMany(d => d.Ativos)
                .HasForeignKey(a => a.DepartamentoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ativo>()
                .HasRequired(a => a.Fornecedor)
                .WithMany(f => f.Ativos)
                .HasForeignKey(a => a.FornecedorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Garantia>()
    .HasRequired(g => g.Ativo)
    .WithOptional(a => a.Garantia);

            // Configurações para a classe Licenca
            modelBuilder.Entity<Licenca>()
                .HasRequired(l => l.Ativo)
                .WithMany(a => a.Licencas)
                .HasForeignKey(l => l.AtivoId)
                .WillCascadeOnDelete(false);

            // Configurações para a classe Manutencao
            modelBuilder.Entity<Manutencao>()
                .HasRequired(m => m.Ativo)
                .WithMany(a => a.Manutencoes)
                .HasForeignKey(m => m.AtivoId)
                .WillCascadeOnDelete(false);

            // Configurações para a classe Garantia
            modelBuilder.Entity<Garantia>()
                .HasRequired(g => g.Fornecedor)
                .WithMany()
                .HasForeignKey(g => g.FornecedorId)
                .WillCascadeOnDelete(false);

            // Configurações para a classe Funcionario
            modelBuilder.Entity<Funcionario>()
                .HasRequired(f => f.Departamento)
                .WithMany(d => d.Funcionarios)
                .HasForeignKey(f => f.DepartamentoId)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

    }
}