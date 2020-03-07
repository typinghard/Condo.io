using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CondominioService.DenunciaContext.Application.ViewModels
{
    public class CriarDenunciaViewModel
    {
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
    }
}
