using WeOpen.Application.Applications.DTOs.ViewModel.FuncionarioView;
using WeOpen.WebApi.Domain.Model.Entities;

namespace WeOpen.Application.Applications.Extensions.ExtensionsViewModel.ExtensionFuncionarioView
{
    public static class ExtensionsFuncionarioViewModel
    {
        public static FuncionarioViewModel TransFormaEmViewModel(this Funcionario funcionario)
        {
            var FuncionarioViewModel = new FuncionarioViewModel()
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Salario = funcionario.Salario,
            };

            return FuncionarioViewModel;
        }


        public static IEnumerable<FuncionarioViewModel> TransFormarEmViewModel
            (this IEnumerable<Funcionario> funcionarioEntity)
                        =>
            funcionarioEntity.Select(FE => FE.TransFormaEmViewModel()).ToList();

    }
}
