using System.ComponentModel.DataAnnotations;

namespace ModeloDados.Models
{
    public class Genero
    {
        /// <summary>
        /// Chave primária do Género
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Género
        /// </summary>
        public String NomeGenero { get; set; }

        /* ********************************************
         * Relacionamentos N-M
         * ******************************************** */

        /// <summary>
        /// Lista de Géneros que o filme pode ter
        /// </summary>
        public ICollection<Filme> ListOfFilme { get; set; } = [];
    }
}
