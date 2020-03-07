using CondominioService.Core.DomainObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Models.Validations
{
    public class NovaDenunciaValidation : EntityValidation<Denuncia>
    {
        public NovaDenunciaValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("Descrição não informada.");
        }
    }
}
