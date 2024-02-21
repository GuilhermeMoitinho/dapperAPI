using WebOpen.WebApi.Applications.ServiceResponse;
using WeOpen.Application.Applications.DTOs.InputModel.UsuarioInput;
using WeOpen.Domain.Model.Entities;

namespace WeOpen.Application.Applications.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Response> Login(UsuarioInputModel userInputModel);

        Task<bool> ObterUsuarioEspecifico(UsuarioInputModel userInputModel);
    }
}
