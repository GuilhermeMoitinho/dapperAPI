using WebOpen.WebApi.Applications.ServiceResponse;
using WeOpen.Application.Applications.DTOs.InputModel.UsuarioInput;
using WeOpen.Application.Applications.Interfaces;
using WeOpen.WebApi.Domain.Model.Interface;

namespace WeOpen.Application.Applications.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository  _repository;

        public UsuarioService(IUsuarioRepository repository)
            => _repository = repository;
            
        

        public async Task<Response> Login(UsuarioInputModel userInputModel)
            => await _repository.Login(userInputModel); 
              
        

        public async Task<bool> ObterUsuarioEspecifico(UsuarioInputModel userInputModel)
            => await _repository.ObterUsuarioEspecifico(userInputModel);
             
        
    }
}
