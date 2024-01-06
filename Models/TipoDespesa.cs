namespace GerenciaAutoNetAPI.Models
{
    public class TipoDespesa
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Descrição do tipo de despesa
        /// </summary>
        public String descricao { get; set; }
        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
