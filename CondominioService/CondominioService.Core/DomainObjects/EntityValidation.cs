using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.Core.DomainObjects
{
    public abstract class EntityValidation<T> : AbstractValidator<T> where T : Entity
    {
        public EntityValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não informado");
        }
    }
}
