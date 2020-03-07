using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CondominioService.DenunciaContext.Application.ViewModels
{
    public class AtualizarDenunciaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
    }
}
