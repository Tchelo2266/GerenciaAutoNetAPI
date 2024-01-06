using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Data.Dtos.TipoDespesa
{
    public class CreateTipoDespesaDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória")]
        String descricao { get; set; }
        DateTime data_cadastro { get; set; }
    }
}
