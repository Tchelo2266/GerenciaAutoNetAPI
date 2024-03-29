﻿using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(100)]
        public String descricao { get; set; }

        /// <summary>
        /// Data que foi cadastrado
        /// </summary>
        public DateTime data_cadastro { get; set; }
    }
}
