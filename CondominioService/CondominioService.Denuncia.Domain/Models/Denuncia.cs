using CondominioService.Core.DomainObjects;
using CondominioService.DenunciaContext.Domain.Models.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Models
{
    public class Denuncia : Entity, IAggregateRoot
    {
        public Denuncia(string descricao)
        {
            Descricao = descricao;
            NovaDenunciaEhValida();
        }

        #region Atributos
        /* Arquivos */
        public Guid UsuarioId { get; protected set; }
        public string Descricao { get; protected set; }
        public Denunciado Denunciado { get; protected set; }
        public TipoDenuncia TipoDenuncia { get; protected set; }
        #endregion

        public void DefinirUsuario(Guid usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public void DefinirDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public ValidationResult NovaDenunciaEhValida()
        {
            return new NovaDenunciaValidation().Validate(this);
        }


    }
}

