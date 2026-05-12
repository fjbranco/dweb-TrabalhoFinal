using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeloDados.Models {
    public class Bilhete {
        /// <summary>
        /// Chave primária do bilhete
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Data da compra do bilhete
        /// </summary>
        public DateTime DataCompra { get; set; }

        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// FK para Sessão do Bilhete
        /// </summary>
        [ForeignKey(nameof(Sessao))]
        public int SessaoFK { get; set; }
        /// <summary>
        /// FK para Sessão do Bilhete
        /// </summary>
        public Sessao SessaoBilhete { get; set; } = null!;

        /// <summary>
        /// FK para Cliente do Bilhete
        /// </summary>
        [ForeignKey(nameof(Cliente))]
        public int ClienteFK { get; set; }
        /// <summary>
        /// FK para Cliente do Bilhete
        /// </summary>
        public Cliente ClienteBilhete { get; set; } = null!;
    }
}
