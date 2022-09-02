using CadastroClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroCliente.Test
{
    public class ClienteTest
    {
        [Fact]
        public void Idade_VinteAnosDepois_RetornaVinte()
        {
            //Arange
            Cliente cliente = new Cliente("Ze Pilintra", DateTime.Now.AddYears(-20), "zpilintra@mail.com");
            //Act
            var idade = cliente.Idade();
            //Assert
            Assert.Equal(20, idade);
        }

        [Fact]
        public void Idade_VinteAnosDepoisEUmDiaDepois_RetornaVinte()
        {
            //Arange
            Cliente cliente = new Cliente("Jose Severino", DateTime.Now.AddYears(-20).AddDays(-1), "zpilintra@mail.com");
            //Act
            var idade = cliente.Idade();
            //Assert
            Assert.Equal(20, idade);
        }
        public void Idade_VinteAnosDepoisEUmDiaDepois_RetornaDezenove()
        {
            //Arange
            Cliente cliente = new Cliente("Jose Severino", DateTime.Now.AddYears(-20).AddDays(1), "zpilintra@mail.com");
            //Act
            var idade = cliente.Idade();
            //Assert
            Assert.Equal(19, idade);
        }

        [Theory]
        [InlineData("Joao", "2010-05-14", "joao@uol.com")]
        [InlineData("", "2010-05-14", "joao@uol.com")]
        [InlineData("Joao", null ,"joao@uol.com")]
        [InlineData("Joao", "2010-05-14", "")]
        public void AtualizaDados_AlteraNomeEmailNAscimento_RetornaAlterado(string nome, DateTime nascimento, string email)
        {
            //Arrange

            Cliente cliente = new Cliente("Jose Severino", new DateTime(2000, 06, 01).AddDays(1), "zpilintra@mail.com");

            //Act
            
            cliente.AtualizaDados(nome, nascimento, email);

            //Assert
            Assert.Equal(cliente.Nome, nome);
            Assert.Equal(cliente.Nascimento, nascimento);
            Assert.Equal(cliente.Email, email);
        }
    }
}
