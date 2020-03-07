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
    public class CommonSteps : IDisposable
    {
        private readonly AutomacaoWebTestsFixture _testsFixture;
        private readonly DenunciaTela _denunciaTela;
        private Denuncia denuncia;
        public CommonSteps(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _denunciaTela = new DenunciaTela(testsFixture.BrowserHelper);
            denuncia = new Faker<Denuncia>("pt_BR")
                .CustomInstantiator((f) => new Denuncia(f.Random.String(20, 'a', 'z')))
                .Generate(1)
                .First();
        }

        [Given(@"O usuário esteja na tela inicial")]
        public void DadoOUsuarioEstejaNaTelaInicial()
        {
            _denunciaTela.NavegarParaUrl(_testsFixture.BrowserHelper.Configuration.DomainUrl);
            var result = _denunciaTela.EstaNaTelaInicial();
            Assert.True(result);
        }
        public void Dispose()
        {
            _denunciaTela.FecharNavegador();
        }
    }
}
