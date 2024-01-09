using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Models
{
    public class Carro
    {
        /// <summary>
        /// Identificador do registro
        /// </summary>
        public int id {  get; set; }

        /// <summary>
        /// Identificador da marca relacionada
        /// </summary>
        [Required(ErrorMessage = "A marca é obrigatória")]
        public int marca_id { get; set; }

        /// <summary>
        /// Marca relacionada
        /// </summary>
        public virtual Marca marca { get; set; }

        /// <summary>
        /// Nome do modelo ou apelido
        /// </summary>
        //[Required(ErrorMessage = "O nome é obrigatório")]
        public String nome { get; set; }

        /// <summary>
        /// Ano do veículo
        /// </summary>
        public int ano { get; set; } = 0;

        /// <summary>
        /// Placa do veículo
        /// </summary>
        public String placa { get; set; } = null;

        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
