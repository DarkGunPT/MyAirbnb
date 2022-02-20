using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TPPweb2122.Models;
using TPPweb2122.Roles;

namespace TPPweb2122.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilizador,IdentityRole<int>,int>
    {   
        public virtual DbSet<Categoria> Categorias {get; set;}
        public virtual DbSet<Imovel> Imoveis {get; set;}
        //public virtual DbSet<Reserva> Reservas {get; set;}
        public virtual DbSet<Avaliacao> Avaliacoes {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>().HasMany(c => c.Reservas).WithOne(t => t.Cliente).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Cliente>().HasMany(c => c.Avaliacoes).WithOne(t => t.cliente).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Funcionario>().HasOne(e => e.Gestor).WithMany(t => t.Funcionarios).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Gestor>().HasMany(e => e.Imoveis).WithOne(t => t.Gestor).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Gestor>().HasMany(e => e.Funcionarios).WithOne(t => t.Gestor).OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            string email = "admin@airbnb.com";
            Utilizador user = new Utilizador()
            {
                Id = 4,
                UserName = email,
                Email = email,
                Nome = "344",
                Morada = "454",
                Telefone = "945",
                NormalizedUserName = email.ToUpper(),
                NormalizedEmail = email.ToUpper(),
                LockoutEnabled = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<Utilizador> passwordHasher = new PasswordHasher<Utilizador>();
            user.PasswordHash = passwordHasher.HashPassword(user, "123Vv#");

            builder.Entity<Utilizador>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(RoleUtils.All);
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<int>>().HasData(
               // new IdentityUserRole<int>() { RoleId = 1, UserId = 2 },
                new IdentityUserRole<int>() { RoleId = 1, UserId = 3 },
                new IdentityUserRole<int>() { RoleId = 1, UserId = 4 }
            );
        }

        public DbSet<TPPweb2122.Models.Cliente> Cliente { get; set; }

        public DbSet<TPPweb2122.Models.Gestor> Gestor { get; set; }

        public DbSet<TPPweb2122.Models.Funcionario> Funcionario { get; set; }

        public DbSet<TPPweb2122.Models.Reserva> Reserva { get; set; }
    }
}
