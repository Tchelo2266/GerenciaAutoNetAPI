using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Data.Dtos.Carro
{
    public class CreateCarroDto
    {
        /// <summary>
        /// Identificador da marca relacionada
        /// </summary>
        [Required(ErrorMessage = "A marca é obrigatória")]
        public int marca_id { get; set; }

        /// <summary>
        /// Nome do modelo ou apelido
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório")]
        public String nome { get; set; }

        /// <summary>
        /// Ano do veículo
        /// </summary>
        public int ano { get; set; }

        /// <summary>
        /// Placa do veículo
        /// </summary>
        public String placa { get; set; }
    }
}
