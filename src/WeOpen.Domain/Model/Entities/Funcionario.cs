using WeOpen.WebApi.Domain.Model.baseEntity;

namespace WeOpen.WebApi.Domain.Model.Entities
{
    public class Funcionario : entityBase
    {
        public string Nome { get; set; } 
        public double Salario { get; set; }
    }
}
