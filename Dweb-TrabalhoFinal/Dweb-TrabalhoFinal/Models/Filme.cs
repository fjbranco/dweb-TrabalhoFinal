using System.ComponentModel.DataAnnotations;

namespace ModeloDados.Models {
    public class Filme {
        /// <summary>
        /// Chave primária do Filme
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Título do filme
        /// </summary>
        public String Titulo { get; set; }

        /// <summary>
        /// Descrição do filme
        /// </summary>
        public String Descricao { get; set; }

        /// <summary>
        /// Nome do ficheiro da imagem do filme
        /// </summary>
        [StringLength(40)]
        public string Imagem { get; set; } = "";

        /// <summary>
        /// Ano do Filme
        /// </summary>
        public String Ano { get; set; }

        /// <summary>
        /// Duração do filme
        /// </summary>
        public String Duracao { get; set; }

        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// FK da Sessão para o filme
        /// </summary>
        public ICollection<Sessao> SessaoFilme { get; set; } = new List<Sessao>();


        /* ********************************************
         * Relacionamentos N-M
         * ******************************************** */

        /// <summary>
        /// Lista de Géneros que o filme pode ter
        /// </summary>
        public ICollection<Genero> ListOfGenero { get; set; } = [];


    }
}
