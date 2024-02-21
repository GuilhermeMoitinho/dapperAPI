using AutoFixture;
using WeOpen.WebApi.Applications.Services;
using WeOpen.WebApi.Domain.Model.Entities;
using WeOpen.WebApi.Domain.Model.Interface;
using Moq;
using WeOpen.Application.Applications.DTOs.InputModel.FuncionarioInput;

namespace WeOpen.WebApiTeste
{
    public class FuncionarioServiceTeste
    {
        [Fact]
        public void MetodoDeCriarFuncionarioSemRetornarNulo()
        {
            // Assets
                var FuncionarioObjectAleatorio = 
                    new Fixture().Create<Funcionario>();

                var funcionarioRepositoryMock = 
                    new Mock<IFuncionarioService>();

                var GarrafaService = 
                    new FuncionarioService(funcionarioRepositoryMock.Object);

                // Act
                var result = 
                    GarrafaService.Add(FuncionarioObjectAleatorio);

                // Assert
                Assert.NotNull(result);
        }
        [Fact]
        public void PegarTodosOsFuncionariosSemRetornarNulo()
        {
                // Assets
                var funcionarioRepositoryMock = 
                    new Mock<IFuncionarioService>();

                var FuncionarioService = 
                    new FuncionarioService
                    (funcionarioRepositoryMock.Object);

                // Act
                var result =
                    FuncionarioService.ListFuncionarios(0, 5);

                // Assert
                Assert.NotNull(result); 
        }

        [Fact]
        public void PegarFuncionarioPorIdSemVoltarNolo()
        {
                //Assets
                var FuncionarioObjectAleatorio = 
                    new Fixture().Create<Funcionario>();

                var funcionarioRepositoryMock = 
                    new Mock<IFuncionarioService>();

                var FuncionarioService = 
                    new FuncionarioService
                    (funcionarioRepositoryMock.Object);

                //Act
                var result = FuncionarioService.
                    PegarFuncionarioPorId(FuncionarioObjectAleatorio.Id);

                //Asset
                Assert.NotNull(result);
        }

        [Fact]
        public void EditarFuncionarioEVerSeFuncionou()
        {
                //Assets
                var FuncionarioObjectAleatorio =
                    new Fixture().Create<Funcionario>();

                var funcionarioEditadoAleattorio =
                   new Fixture().Create<FuncionarioInputModel>();

                var funcionarioRepositoryMock =
                    new Mock<IFuncionarioService>();

                var FuncionarioService =
                    new FuncionarioService
                    (funcionarioRepositoryMock.Object);

                //Act
                var result = FuncionarioService.
                    UpdateFuncionarios(funcionarioEditadoAleattorio 
                                      ,FuncionarioObjectAleatorio.Id);

                //Asset
                Assert.NotNull(result);
        }

        [Fact]
        public void DeletarFuncionarioEVerSeFuncionou()
        {
            //Assets
            var FuncionarioObjectAleatorio =
                new Fixture().Create<Funcionario>();

            var funcionarioRepositoryMock =
                new Mock<IFuncionarioService>();

            var FuncionarioService =
                new FuncionarioService
                (funcionarioRepositoryMock.Object);

            //Act
            var result = FuncionarioService.
                DeleteFuncionario(FuncionarioObjectAleatorio.Id);

            //Asset
            Assert.NotNull(result);
        }
    }
}