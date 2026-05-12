using System.ComponentModel.DataAnnotations;

namespace ModeloDados.Models {
    public class Sala {
        /// <summary>
        /// Chave primária da Sala
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da Sala
        /// </summary>
        public String Nome { get; set; }

        /// <summary>
        /// Capacidade da Sala
        /// </summary>
        public int Capacidade { get; set; }

        /// <summary>
        /// Localidade da Sala
        /// </summary>
        public String Localidade { get; set; }

        /// <summary>
        /// Morada da Sala
        /// </summary>
        public String Morada { get; set; }
        
        /// <summary>
        /// Código postal
        /// </summary>
        public string CodigoPostal { get; set; }

        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// FK da Sessão para a sala
        /// </summary>
        public ICollection<Sessao> SessaoSala { get; set; } = new List<Sessao>();

    }
}
