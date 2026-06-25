namespace Dweb_TrabalhoFinal.Models.ViewModels {
    /// <summary>
    /// Lista de filmes
    /// </summary>
    public class FilmesDTO {
        /// <summary>
        /// ID do filme na base de dados
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título do filme
        /// </summary>
        public string Titulo { get; set; } = "";

        /// <summary>
        /// Descrição do filme
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Nome do ficheiro da imagem do filme
        /// </summary>
        public string Imagem { get; set; } = "";

        /// <summary>
        /// Ano do filme
        /// </summary>
        public string Ano { get; set; } = "";
    }
}
