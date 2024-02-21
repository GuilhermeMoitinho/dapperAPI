using System.ComponentModel.DataAnnotations;
using WeOpen.WebApi.Domain.Model.baseEntity;

namespace WeOpen.Domain.Model.Entities
{
    public class Usuario : entityBase
    {
        [Required(ErrorMessage = "O campo de E-mail é obrigatório.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo de Senha é obrigatório.")]
        public string Senha { get; set; } = string.Empty;
    }
}
