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
    public class AdicionarDenunciaSteps : IDisposable
    {
        private readonly AutomacaoWebTestsFixture _testsFixture;
        private readonly DenunciaTela _denunciaTela;
        private Denuncia denuncia;
        public AdicionarDenunciaSteps(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _denunciaTela = new DenunciaTela(testsFixture.BrowserHelper);
            denuncia = new Faker<Denuncia>("pt_BR")
                .CustomInstantiator((f) => new Denuncia(f.Random.String(20, 'a', 'z')))
                .Generate(1)
                .First();
        }

        [Given(@"O usuário clicou em Adicionar Denuncia")]
        public void DadoOUsuarioClicouEmAdicionarDenuncia()
        {
            _denunciaTela.ClicarNoBotaoDeAcessarTelaDeNovaDenuncia();
        }

        [When(@"O usuário preencher os dados da nova denuncia")]
        public void QuandoOUsuarioPreencherOsDadosDaNovaDenuncia(Table table)
        {
            _denunciaTela.PreencherInformacoesDenuncia(denuncia);
            var result = _denunciaTela.ValidarPreenchimentoInformacoesDenuncia(denuncia);
            Assert.True(result);
        }

        [When(@"Clicar no botão Gravar")]
        public void QuandoClicarNoBotaoGravar()
        {
            _denunciaTela.ClicarNoBotaoGravar();
        }

        [Then(@"O usuário será redirecionado para a tela de visualização de denúncias")]
        public void EntaoOUsuarioSeraRedirecionadoParaATelaDeVisualizacaoDeDenuncias()
        {
            var result = _denunciaTela.EstaNaTelaDeListagemDeDenuncias();
            Assert.True(result);
        }

        [Then(@"O usuário receberá avisos sobre campos obrigatórios não preenchidos")]
        public void EntaoOUsuarioReceberaAvisosSobreCamposObrigatoriosNaoPreenchidos()
        {
            _denunciaTela.ValidarSeMensagensDeCamposObrigatoriosForamExibidas();
        }

        public void Dispose()
        {
            _denunciaTela.FecharNavegador();
        }
    }
}
