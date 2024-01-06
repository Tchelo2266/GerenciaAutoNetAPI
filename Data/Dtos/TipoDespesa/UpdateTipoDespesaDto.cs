namespace GerenciaAutoNetAPI.Data.Dtos.TipoDespesa
{
    public class UpdateTipoDespesaDto
    {
        /// <summary>
        /// Identificador do registro
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Descrição do tipo de despesa
        /// </summary>
        public String descricao { get; set; }
    }
}
