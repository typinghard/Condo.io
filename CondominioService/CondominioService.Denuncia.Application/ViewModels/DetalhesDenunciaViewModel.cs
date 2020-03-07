using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CondominioService.DenunciaContext.Application.ViewModels
{
    public class DetalhesDenunciaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Data Criação")]
        public DateTime CriadoAs { get; set; }

        [DisplayName("Última Atualização")]

        public DateTime AtualizadoAs { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
    }
}
