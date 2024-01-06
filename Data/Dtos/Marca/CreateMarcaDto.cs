using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Data.Dtos.Marca
{
    public class CreateMarcaDto
    {
        /// <summary>
        /// Nome da marca
        /// </summary>
        [Required(ErrorMessage = "O nome da marca é obrigatório")]
        [MaxLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres")]
        public string nome { get; set; }
    }
}
