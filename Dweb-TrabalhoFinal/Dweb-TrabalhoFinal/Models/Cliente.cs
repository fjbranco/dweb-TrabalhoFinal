using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeloDados.Models
{
    public class Cliente
    {
        /// <summary>
        /// Chave primária do Cliente
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public String Nome { get; set; }

        /// <summary>
        /// Email do Cliente
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Telemóvel do Cliente
        /// </summary>
        [Display(Name = "Telemóvel")]
        [StringLength(19)]
        [RegularExpression("([+]|(00)[0-9]{2,5})?[0-9]{6,12}",
                           ErrorMessage = "O {0} deve conter apenas números e um sinal de mais opcional no início.")]
        public String Telemovel { get; set; }

        /// <summary>
        /// NIF do Cliente
        /// </summary>
        public String NIF { get; set; }

        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        //// <summary>
        /// Lista de bilhetes do cliente
        /// </summary>
        public ICollection<Bilhete> BilhetesCliente { get; set; } = new List<Bilhete>();
    }
}
