using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Test.Testes_Automatizados
{
    public abstract class PageObjectModel
    {
        protected readonly SeleniumHelper Helper;

        protected PageObjectModel(SeleniumHelper helper)
        {
            Helper = helper;
        }

        public string ObterUrl()
        {
            return Helper.ObterUrl();
        }

        public void NavegarParaUrl(string url)
        {
            Helper.IrParaUrl(url);
        }
    }
}
