using ModeloDados.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dweb_TrabalhoFinal.Data.Seed {
    internal class DbInitializer {

        internal static async void Initialize(ApplicationDbContext dbContext) {

            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            // var auxiliar
            bool haAdicao = false;


            // Se não houver géneros, cria-os
            var generos = Array.Empty<Genero>();

            if (!dbContext.Generos.Any()) {
                generos = [
                    new Genero { NomeGenero = "Ação" },
                    new Genero { NomeGenero = "Ficção Científica" },
                    new Genero { NomeGenero = "Drama" },
                    new Genero { NomeGenero = "Thriller" }
                ];
                await dbContext.Generos.AddRangeAsync(generos);
                haAdicao = true;
            } else {
                generos = dbContext.Generos.ToArray();
            }

            // Se não houver filmes, cria-os
            var filmes = Array.Empty<Filme>();

            if (!dbContext.Filmes.Any()) {
                filmes = [
                    new Filme { Titulo = "Matrix", Descricao = "Acção futurística", Imagem = "matrix.jpg", Ano = "1999",  Duracao = "136", ListOfGenero = new List<Genero> { generos[0] } },
                    new Filme { Titulo = "O Senhor dos Anéis", Descricao = "Uma jornada épica", Imagem = "senhor_aneis.jpg", Ano = "2001",  Duracao = "178", ListOfGenero = new List<Genero> { generos[2] } },
                    new Filme { Titulo = "Inception", Descricao = "Um thriller psicológico", Imagem = "inception.jpg", Ano = "2010",  Duracao = "148", ListOfGenero = new List<Genero> { generos[3] } },
                    new Filme { Titulo = "Exterminador 2", Descricao = "Ação e ficção científica", Imagem = "exterminador2.jpg", Ano = "1991",  Duracao = "137", ListOfGenero = new List<Genero> { generos[0], generos[1] } }
                //adicionar outros filmes
                ];
                await dbContext.Filmes.AddRangeAsync(filmes);
                haAdicao = true;
            }


            // Se não houver Cliente, cria-os
            var clientes = Array.Empty<Cliente>();
            if (!dbContext.Clientes.Any()) {
                clientes = [
                    new Cliente { Nome="João Mendes", Email="jmendeste@exemplo.com", NIF="123456789", Telemovel="919876543" },
                    new Cliente { Nome="Maria Sousa", Email="msousa@exemplo.com", NIF="123459876", Telemovel="912345678" },
                    new Cliente { Nome="Ana Paula Silva", Email="apsilva@exemplo.com", NIF="123459867", Telemovel="935678921"  }
                ];
                await dbContext.Clientes.AddRangeAsync(clientes);
                haAdicao = true;
            }


            // Se não houver Sala, cria-os
            var salas = Array.Empty<Sala>();
            if (!dbContext.Salas.Any()) {
                salas = [
                    new Sala { Nome ="Sala 1", Capacidade = 100 , Localidade="Lisboa",  Morada="Av. Paulista, 1000", CodigoPostal="1000-000" },
                    new Sala { Nome = "Sala 2", Capacidade = 150 , Localidade="Porto", Morada="R. do Carmo, 100", CodigoPostal="4000-000" },
                    new Sala { Nome = "Sala 3", Capacidade = 200 , Localidade="Braga", Morada="Praça da República, 50", CodigoPostal="4700-000" }
                ];
                await dbContext.Salas.AddRangeAsync(salas);
                haAdicao = true;
            }


            // Se não houver bilhetes, cria-os
            var bilhetes = Array.Empty<Bilhete>();
            if (!dbContext.Bilhetes.Any()) {
                bilhetes = [
                    new Bilhete { DataCompra = DateTime.Now, SessaoFK = 1, ClienteFK = 1 },
                    new Bilhete { DataCompra = DateTime.Now, SessaoFK = 2, ClienteFK = 2 },
                    new Bilhete { DataCompra = DateTime.Now, SessaoFK = 3, ClienteFK = 3 }
                ];
                await dbContext.Bilhetes.AddRangeAsync(bilhetes);
                haAdicao = true;
            }

            // Se não houver sessões, cria-as
            var sessoes = Array.Empty<Sessao>();
            if (!dbContext.Sessoes.Any()) {
                sessoes = [
                    new Sessao { DataSessao = DateTime.Parse("2026-06-26"), HoraSessao = DateTime.Parse("19:00"), Preco = 10.00m, FilmeFK = 1, SalaFK = 1 },
                    new Sessao { DataSessao = DateTime.Parse("2026-07-27"), HoraSessao = DateTime.Parse("21:00"), Preco = 12.00m, FilmeFK = 2, SalaFK = 2 },
                    new Sessao { DataSessao = DateTime.Parse("2026-07-28"), HoraSessao = DateTime.Parse("23:00"), Preco = 15.00m, FilmeFK = 3, SalaFK = 3 }
                ];
                await dbContext.Sessoes.AddRangeAsync(sessoes);
                haAdicao = true;
            }


            try
            {
                if (haAdicao)
                {
                    // tornar persistentes os dados
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
