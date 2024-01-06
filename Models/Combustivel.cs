using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Models
{
    public class Combustivel
    {
        /// <summary>
        /// Identificador do registro
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Descrição do combustível
        /// </summary>
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(100)]
        public string descricao { get; set; }

        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
