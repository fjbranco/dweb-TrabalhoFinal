using Microsoft.EntityFrameworkCore;

namespace Dweb_TrabalhoFinal.Models.ViewModels {
    public class SessoesSimplerDTO {
        /// <summary>
        /// Data da sessão
        /// </summary>
        public DateTime DataSessao { get; set; }
        /// <summary>
        /// Hora da sessão
        /// </summary>
        public DateTime HoraSessao { get; set; }
        /// <summary>
        /// Preço da sessão
        /// </summary>
        [Precision(5, 2)]
        public int Preco { get; set; }
    }
}
