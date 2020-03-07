using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CondominioService.DenunciaContext.Domain.Test.Testes_Automatizados
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _config;

        public ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string DomainUrl => _config.GetSection("DomainUrl").Value;
        public string NovaDenunciaUrl => $"{DomainUrl}{_config.GetSection("NovaDenunciaUrl").Value}";
        public string ListarDenunciasUrl => $"{DomainUrl}{_config.GetSection("ListarDenunciasUrl").Value}";
        public string DetalheDenunciaUrl => $"{DomainUrl}{_config.GetSection("DetalheDenunciaUrl").Value}";
        public string LoginUrl => $"{DomainUrl}{_config.GetSection("LoginUrl").Value}";
        public string WebDrivers => $"{_config.GetSection("WebDrivers").Value}";
        public string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
    }
}
