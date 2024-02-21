using WeOpen.Application.Applications.DTOs.InputModel.FuncionarioInput;
using WeOpen.Application.Applications.DTOs.ViewModel.FuncionarioView;
using WeOpen.WebApi.Domain.Model.Entities;
using WeOpen.WebApi.Domain.Model.Interface;

namespace WeOpen.WebApi.Applications.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository)
                        =>
            _repository = repository;
        

        public async Task Add(Funcionario funcionario)
            => await _repository.Add(funcionario);

        public async Task DeleteFuncionario(Guid id)
        {
            await _repository.DeleteFuncionario(id);
        }

        public async Task<IEnumerable<Funcionario>> ListFuncionarios(int skip, int take)
        {
           var funcionariosList =  await _repository.
                ListFuncionarios(skip, take);

            return funcionariosList;
        }

        public async Task<FuncionarioViewModel> PegarFuncionarioPorId(Guid id)
        {
            var FuncionarioViewModel = await _repository.PegarFuncionarioPorId(id);

            return FuncionarioViewModel;
        }

        public async Task UpdateFuncionarios(FuncionarioInputModel funcionarioINputModel, Guid id)
           => await _repository.UpdateFuncionarios(funcionarioINputModel, id);
            
        
    }
}
