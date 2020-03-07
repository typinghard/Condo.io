using CondominioService.DenunciaContext.Domain.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Test.Testes_Automatizados
{
    public class DenunciaTela : PageObjectModel
    {
        public DenunciaTela(SeleniumHelper helper) : base(helper) { }

        public void AcessarUrlBase()
        {
            Helper.IrParaUrl(Helper.Configuration.DomainUrl);
        }
        public void ClicarNoBotaoDeAcessarTelaDeNovaDenuncia()
        {
            Helper.ObterElementoPorXPath("/html/body/div/main/a").Click();
        }

        public void PreencherInformacoesDenuncia(Denuncia denuncia)
        {
            Helper.PreencherTextBoxPorId("Descricao", denuncia.Descricao);
        }

        public bool ValidarPreenchimentoInformacoesDenuncia(Denuncia denuncia)
        {
            if (Helper.ObterValorTextBoxPorId("Descricao") != denuncia.Descricao) return false;

            return true;
        }

        public void ClicarNoBotaoGravar()
        {
            var botao = Helper.ObterElementoPorId("btnGravar");
            botao.Click();
        }

        public bool EstaNaTelaDeListagemDeDenuncias()
        {
            return Helper.ValidarConteudoUrl(Helper.Configuration.ListarDenunciasUrl);
        }
        public bool EstaNaTelaDeDetalheDaDenuncia(string denunciaId)
        {
            return Helper.ValidarConteudoUrl(Helper.Configuration.DetalheDenunciaUrl + denunciaId.ToLower());
        }
        public bool EstaNaTelaInicial()
        {
            return Helper.ValidarConteudoUrl(Helper.Configuration.DomainUrl);
        }
        public bool ExisteDenunciaNaTabela()
        {
            return Helper.ObterElementoPorXPath("/html/body/div/main/div[1]/div[2]/div[2]/table/tbody/tr/td").Text != "Nenhum registro encontrado";
        }
        public string ObterPrimeiraDenunciaDaTabela()
        {
            var href = Helper.ObterElementoPorXPath("/html/body/div/main/div[1]/div[2]/div[2]/table/tbody/tr/td[4]/div/a[1]").GetAttribute("href");
            var splitted = href.Split("/");
            return splitted[splitted.Length - 1];
        }
        public void ClicarEmDetalheDenuncia()
        {
            Helper.ObterElementoPorXPath("/html/body/div/main/div[1]/div[2]/div[2]/table/tbody/tr[1]/td[4]/div/a[2]")
                  .Click();
        }

        public void ValidarSeMensagensDeCamposObrigatoriosForamExibidas()
        {
            var descricaoError = Helper.ObterElementoPorId("Descricao-error");
        }

        public void FecharNavegador()
        {
            Helper.FecharNavegador();
        }
    }

}
