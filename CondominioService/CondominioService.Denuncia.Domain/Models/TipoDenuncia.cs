using CondominioService.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Models
{
    public class TipoDenuncia
    {
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Desabilitado { get; protected set; }

        /*
         
         - Mais de uma propriedade no ENUM.

            Perturbação do Sossego
            Mau Cheiro (Gás, Lixo, etc)
            Vandalismo
            Uso da Garagem
            Mal uso da área comum (pscina, churrasqueira, quadras, ruas, parque, salas)
            *******Funcionarios
            Outros 

         */
    }
}
