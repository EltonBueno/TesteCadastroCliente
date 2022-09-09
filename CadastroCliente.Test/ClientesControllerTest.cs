using CadastroClientes.Contracts;
using CadastroClientes.Controllers;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CadastroClientes.Models;

namespace CadastroCliente.Test
{
    public class ClientesControllerTest
    {
        Mock<IClienteRepository> _repository;

        public ClientesControllerTest()
        {
            _repository = new Mock<IClienteRepository>();
        }



        [Fact]
        public async void GetClientes_ExecutaAcao_RetornaOkAction()
        {
            //Arrange
           
            ClientesController controller = new ClientesController(_repository.Object);

            //Act
            var consulta = await controller.GetClientes();

            //Assert
            Assert.IsType<OkObjectResult>(consulta.Result);
            //Assert.IsAssignableFrom<IEnumerable>(result.Result.Value);

        }

        [Fact]
        public async void GetClientes_executaAcao_RetornaArrayClientes()
        {
            //Arrange
            ClientesController controller = new ClientesController(_repository.Object);

            var clientes = new List<Cliente>()
            { 
                new Cliente("Irineu", DateTime.Now, "mail"),
                new Cliente("Irineuu", DateTime.Now, "mail2")
            };

            _repository.Setup(repo => repo.GetClientes()).Returns(Task.FromResult(clientes));

            //Act
            var consulta = await controller.GetClientes();

            //Assert
            var listaClientes = Assert.IsType<List<Cliente>>((consulta.Result as OkObjectResult).Value);
            Assert.Equal(2, listaClientes.Count);
        }      
        
        [Fact]
        public async void GetCliente_executaAcao_RetornaArrayClientes()
        {
            //Arrange
            ClientesController controller = new ClientesController(_repository.Object);

           
            
          Cliente cliente1 = new Cliente("Irineu", DateTime.Now, "mail");
           

            _repository.Setup(repo => repo.GetClienteById(1)).Returns(Task.FromResult(cliente1));

            //Act
            var consulta = await controller.GetCliente(1);

            //Assert
            var cli = Assert.IsType<Cliente>(consulta.Value);
            //var Cliente = Assert.IsType<Cliente>((consulta.Result as OkObjectResult).Value);
            //Assert.Equal(1 , listaClientes);
            
        }


    }
}
