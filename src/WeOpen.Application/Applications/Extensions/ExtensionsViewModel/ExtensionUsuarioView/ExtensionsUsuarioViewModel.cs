using WeOpen.Application.Applications.DTOs.ViewModel.FuncionarioView;
using WeOpen.Application.Applications.DTOs.ViewModel.UsuarioView;
using WeOpen.Domain.Model.Entities;
using WeOpen.WebApi.Domain.Model.Entities;

namespace WeOpen.Application.Applications.Extensions.ExtensionsViewModel.ExtensionUsuarioView
{
    public static class ExtensionsUsuarioViewModel
    {
        public static UsuarioViewModel TransFormaUsuarioEmViewModel(this Usuario usuario)
        {
            var UsuarioViewModel = new UsuarioViewModel()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Senha = usuario.Senha,
            };

            return UsuarioViewModel;
        }
    }
}
