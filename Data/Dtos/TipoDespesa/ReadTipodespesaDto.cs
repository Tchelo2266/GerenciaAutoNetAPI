namespace GerenciaAutoNetAPI.Data.Dtos.TipoDespesa
{
    public class ReadTipoDespesaDto
    {
        /// <summary>
        /// Identificador do registro
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Descrição do tipo de despesa
        /// </summary>
        public String descricao { get; set; }
        /// <summary>
        /// Data do cadastro
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
