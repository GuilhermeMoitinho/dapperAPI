using WeOpen.Application.Applications.DTOs.InputModel.UsuarioInput;
using WeOpen.Domain.Model.Entities;

namespace WeOpen.Application.Applications.Extensions.ExtensionsInputModel.ExtensionUsuarioInput
{
    public static class ExtensionUsuarioInputModel
    {
        public static Usuario TransFormarUsuarioEmEntity(this UsuarioInputModel userInputModel)
        {
            var UsuarioEntity = new Usuario()
            {
                Email = userInputModel.Email,
                Senha = userInputModel.Senha,
            };

            return UsuarioEntity;
        }
    }
}
