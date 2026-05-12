using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;

namespace Dweb_TrabalhoFinal.Data
{
    /// <summary>
    /// Base de dados do projeto da aplicação
    /// </summary>
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        /* tabelas da base de dados */
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Bilhete> Bilhetes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
