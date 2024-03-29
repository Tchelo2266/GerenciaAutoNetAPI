﻿using System.ComponentModel.DataAnnotations;

namespace GerenciaAutoNetAPI.Data.Dtos.TipoDespesa
{
    public class CreateTipoDespesaDto
    {
        /// <summary>
        /// Descrição do tipo de despesa
        /// </summary>
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public String descricao { get; set; }
    }
}
