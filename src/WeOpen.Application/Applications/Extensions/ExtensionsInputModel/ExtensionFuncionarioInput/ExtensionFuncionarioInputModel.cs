using WeOpen.Application.Applications.DTOs.InputModel.FuncionarioInput;
using WeOpen.WebApi.Domain.Model.Entities;

namespace WeOpen.Application.Applications.Extensions.ExtensionsInputModel.ExtensionFuncionarioInput
{
    public static class ExtensionFuncionarioInputModel
    {
        public static Funcionario TransFormarEmEntity(this FuncionarioInputModel funcionarioViewModel)
        {
            var FuncinarioEntity = new Funcionario()
            {
                Nome = funcionarioViewModel.Nome,
                Salario = funcionarioViewModel.Salario,
            };

            return FuncinarioEntity;
        }
    }
}
