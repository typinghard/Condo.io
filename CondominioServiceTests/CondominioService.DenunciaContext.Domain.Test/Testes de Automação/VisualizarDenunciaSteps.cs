using Bogus;
using CondominioService.DenunciaContext.Domain.Models;
using CondominioService.DenunciaContext.Domain.Test.Testes_Automatizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace CondominioService.DenunciaContext.Domain.Test.Testes_de_Comportamento
{
    [Binding]
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class VisualizarDenunciaSteps : IDisposable
    {
        private readonly AutomacaoWebTestsFixture _testsFixture;
        private readonly DenunciaTela _denunciaTela;
        private string denunciaId;
        public VisualizarDenunciaSteps(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _denunciaTela = new DenunciaTela(testsFixture.BrowserHelper);
        }

        [Given(@"Existe denúncias na tabela")]
        public void DadoExisteDenunciasNaTabela()
        {
            var result = _denunciaTela.ExisteDenunciaNaTabela();
            Assert.True(result);
        }

        [When(@"O usuário clicar para visualizar detalhe uma denuncia")]
        public void QuandoOUsuarioClicarParaVisualizarUmaDenuncia()
        {
            //Arrange
            denunciaId = _denunciaTela.ObterPrimeiraDenunciaDaTabela();
            
            //Act
            _denunciaTela.ClicarEmDetalheDenuncia();
        }

        [Then(@"O usuário será redirecionado para a tela de detalhe da denúncia")]
        public void EntaoOUsuarioSeraRedirecionadoParaATelaDeVisualizacaoDaDenuncia()
        {
            var result = _denunciaTela.EstaNaTelaDeDetalheDaDenuncia(denunciaId);
            Assert.True(result);
        }

        public void Dispose()
        {
            _denunciaTela.FecharNavegador();
        }

    }
}
