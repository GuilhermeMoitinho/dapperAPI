using System.ComponentModel.DataAnnotations;

namespace WeOpen.Application.Applications.DTOs.InputModel.UsuarioInput
{
    public class UsuarioInputModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
