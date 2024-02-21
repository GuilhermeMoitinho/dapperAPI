using WeOpen.Application.Applications.DTOs.InputModel.FuncionarioInput;
using WeOpen.Application.Applications.DTOs.ViewModel.FuncionarioView;
using WeOpen.WebApi.Domain.Model.Entities;

namespace WeOpen.WebApi.Domain.Model.Interface
{
    public interface IFuncionarioRepository 
    {
        Task Add(Funcionario funcionario);
        Task<IEnumerable<Funcionario>> ListFuncionarios(int skip, int take);
        Task<FuncionarioViewModel> PegarFuncionarioPorId(Guid id);
        Task UpdateFuncionarios(FuncionarioInputModel funcionarioINputModel, Guid id);
        Task DeleteFuncionario(Guid id);
    }
}
