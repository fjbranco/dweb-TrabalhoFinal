using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeloDados.Models
{
    public class Sessao
    {

        /// <summary>
        /// Chave primária da sessão
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Data da Sessão
        /// </summary>
        public DateTime DataSessao { get; set; }

        /// <summary>
        /// Hora da Sessão
        /// </summary>
        public DateTime HoraSessao { get; set; }

        /// <summary>
        /// preço da Sessão
        /// </summary>
        [Display(Name = "Preço")]
        [Precision(5, 2)]
        public decimal Preco { get; set; }


        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// FK do bilhete para a sessão
        /// </summary>
        public ICollection<Bilhete> BilheteSessao { get; set; } = new List<Bilhete>();

        /// <summary>
        /// FK para Sala da Sessão
        /// </summary>
        [ForeignKey(nameof(Sala))]
        public int SalaFK { get; set; }
        /// <summary>
        /// FK para Sala da Sessão
        /// </summary>
        public Sala SalaSessao { get; set; } = null!;

        /// <summary>
        /// FK para Filme da Sessão
        /// </summary>
        [ForeignKey(nameof(Filme))]
        public int FilmeFK { get; set; }
        /// <summary>
        /// FK para Sala da Sessão
        /// </summary>
        public Filme FilmeSessao { get; set; } = null!;


    }
}
