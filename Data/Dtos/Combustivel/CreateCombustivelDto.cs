using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Data.Dtos.Combustivel
{
    public class CreateCombustivelDto
    {
        /// <summary>
        /// Descrição do combustível
        /// </summary>
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(100, ErrorMessage ="A descrição não pode ultrapassar 100 caracteres")]
        public String descricao { get; set; }

        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
