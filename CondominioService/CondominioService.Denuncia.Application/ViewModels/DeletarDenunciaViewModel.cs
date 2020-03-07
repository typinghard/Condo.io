using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CondominioService.DenunciaContext.Application.ViewModels
{
    public class DeletarDenunciaViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
