using Bogus;
using CondominioService.DenunciaContext.Domain.Models;
using System;
using System.Linq;
using Xunit;

namespace CondominioService.DenunciaContext.Domain.Test
{
    public class DenunciaTest
    {
        private Denuncia denuncia;
        public DenunciaTest()
        {
            denuncia = new Faker<Denuncia>("pt_BR")
                .CustomInstantiator((f) => new Denuncia(f.Random.String(20, 'a', 'z')))
                .Generate(1)
                .First();
        }

        [Fact(DisplayName = "Denuncia - Definir Usuário - Usuario deve ser alterado")]
        public void Denuncia_DefinirUsuario_UsuarioDeveSerAlterado()
        {
            //Arrange
            var usuarioId = Guid.NewGuid();

            //Act
            denuncia.DefinirUsuario(usuarioId);

            //Assert
            Assert.Equal(usuarioId, denuncia.UsuarioId);
        }

        [Fact(DisplayName = "Denuncia_DefinirDescricao_DescricaoDeveSerAlterada")]
        public void Denuncia_DefinirDescricao_DescricaoDeveSerAlterada()
        {
            //Arrange
            var novaDescricao = "Nova descrição";

            //Act
            denuncia.DefinirDescricao(novaDescricao);

            //Assert
            Assert.Equal(novaDescricao, denuncia.Descricao);
        }

        [Fact(DisplayName = "Denuncia_NovaDenunciaEhValida_DeveSerValido")]
        public void Denuncia_NovaDenunciaEhValida_DeveSerValido()
        {
            //Act
            var ehValido = denuncia.NovaDenunciaEhValida().IsValid;

            //Assert
            Assert.True(ehValido);
        }

        [Fact(DisplayName = "Denuncia_NovaDenunciaEhValida_DeveSerInvalido")]
        public void Denuncia_NovaDenunciaEhValida_DeveSerInvalido()
        {
            //Arrange
            denuncia = new Faker<Denuncia>("pt_BR")
                .CustomInstantiator((f) => new Denuncia(""))
                .Generate(1)
                .First();

            //Act
            var ehValido = denuncia.NovaDenunciaEhValida().IsValid;

            //Assert
            Assert.False(ehValido);
        }


    }
}
