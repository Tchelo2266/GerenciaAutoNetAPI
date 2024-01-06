using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Models
{
    public class Marca
    {
        /// <summary>
        /// Identificador do registro
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nome da marca
        /// </summary>
        [Required(ErrorMessage = "O nome da marca é obrigatório")]
        [MaxLength(100, ErrorMessage ="A descrição não pode ultrapassar 100 caracteres")]
        public string nome { get; set; }

        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
