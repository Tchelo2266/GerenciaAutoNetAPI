using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Data.Dtos.Marca
{
    public class ReadMarcaDto
    {
        /// <summary>
        /// Identificador do registro
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nome da marca
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
