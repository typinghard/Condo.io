using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CondominioService.DenunciaContext.Domain.Test.Testes_Automatizados
{
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class AutomacaoWebFixtureCollection : ICollectionFixture<AutomacaoWebTestsFixture> { }

    public class AutomacaoWebTestsFixture
    {
        public SeleniumHelper BrowserHelper;
        public readonly ConfigurationHelper Configuration;

        public AutomacaoWebTestsFixture()
        {
            Configuration = new ConfigurationHelper();
            BrowserHelper = new SeleniumHelper(Configuration, false);
        }
    }
}
