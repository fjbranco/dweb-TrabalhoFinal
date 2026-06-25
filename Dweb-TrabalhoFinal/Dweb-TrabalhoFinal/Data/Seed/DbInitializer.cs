using ModeloDados.Models;

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


            try {
                if (haAdicao) {
                    // tornar persistentes os dados
                    dbContext.SaveChanges();
                }
            } catch (Exception ex) {

                throw;
            }
            // Se não houver bilhetes, cria-os
            var bilhetes = Array.Empty<Bilhete>();
            if (!dbContext.Salas.Any())
            {
                bilhetes = [
                    new Bilhete { DataCompra = "18/07/2026" , SessaoFK="",   SessaoBilhete="",ClienteFK="", ClienteBilhete="" },
                    new  Bilhete { DataCompra = "22/07/2026" , SessaoFK="",   SessaoBilhete="",ClienteFK="", ClienteBilhete="" },
                    new  Bilhete{ DataCompra = "24/07/2026" , SessaoFK="",   SessaoBilhete="",ClienteFK="", ClienteBilhete="" }
                ];
                await dbContext.Salas.AddRangeAsync(salas);
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
