namespace GerenciaAutoNetAPI.Data.Dtos.Combustivel
{
    public class ReadCombustivelDto
    {
        /// <summary>
        /// Identificador do combustível
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Descrição do combustível
        /// </summary>
        public string descricao { get; set; }

        /// <summary>
        /// Data de cadastro do combustível
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
