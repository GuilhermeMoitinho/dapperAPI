using WebOpen.WebApi.Applications.ServiceResponse;
using WeOpen.Application.Applications.DTOs.ViewModel.FuncionarioView;

namespace WeOpen.Application.Applications.Extensions.ExtensionsResponse.ExtensionFuncionarioResponse
{
    public static class ExtensionsFuncionarioServiceResponse
    {
        public static Response ResponseFuncionarioViewModel(this FuncionarioViewModel funcViewModel)
        {
            var response = new Response()
            {
                Mensagem = "Tudo certo!",
                Dados = funcViewModel,
                Sucesso = true
            };

            return response;
        }

        public static Response ResponseListFuncionarioViewModel
            (this IEnumerable<FuncionarioViewModel>
                         ListFuncionariosViewModel)
        {
            var response = new Response()
            {
                Mensagem = "Tudo certo!",
                Dados = ListFuncionariosViewModel,
                Sucesso = true
            };

            return response;
        }

    }

}
