using WebOpen.WebApi.Applications.ServiceResponse;
using WeOpen.Application.Applications.DTOs.ViewModel.UsuarioView;

namespace WeOpen.Application.Applications.Extensions.ExtensionsResponse.ExtensionUsuarioResponse
{
    public static class ExtensionsUsuarioServiceResponse
    {
        public static Response ResponseUsuarioViewModel(this UsuarioViewModel usuarioViewModel)
        {
            var response = new Response()
            {
                Mensagem = "Tudo certo!",
                Dados = usuarioViewModel,
                Sucesso = true
            };

            return response;
        }
    }
}
