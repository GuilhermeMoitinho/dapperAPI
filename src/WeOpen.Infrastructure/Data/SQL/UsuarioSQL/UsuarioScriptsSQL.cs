using WeOpen.Domain.Model.Interface;
using WeOpen.WebApi.Domain.Model.Entities;

namespace WeOpen.Infrastructure.Data.SQL.UsuarioSQL
{
    public class UsuarioScriptsSQL : IUsuarioScriptsSQL
    {
        public string ObterUsuarioExistente()
        {
            return "SELECT * FROM Usuario WHERE Email = @Email AND Senha = @Senha";
        }
    }
}
