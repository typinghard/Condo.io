using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CondominioService.DenunciaContext.Application.ViewModels
{
    public class DenunciadoViewModel
    {
        [Key]
        public Guid ResidenciaDenunciadoId { get; set; }

    }
}
