
using GerenciaAutoNetAPI.Data.Dtos.Marca;

namespace GerenciaAutoNetAPI.Data.Dtos.Carro
{
    public class ReadCarroDto
    {
        /// <summary>
        /// Identificador do registro
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Identificador da marca relacionada
        /// </summary>
        public required int marca_id { get; set; }

        public ReadMarcaDto marca { get; set; }

        /// <summary>
        /// Nome do modelo ou apelido
        /// </summary>
        public String nome { get; set; }

        /// <summary>
        /// Ano do veículo
        /// </summary>
        public int ano { get; set; }

        /// <summary>
        /// Placa do veículo
        /// </summary>
        public String placa { get; set; }

        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
