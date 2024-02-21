using FluentValidation;
using WeOpen.Application.Applications.DTOs.InputModel.FuncionarioInput;

namespace WeOpen.Application.Applications.Validacoes.ValidacaoFuncionario
{
    public class FuncionarioValidacao : AbstractValidator<FuncionarioInputModel>
    {
        public FuncionarioValidacao()
        {
            RuleFor(customer => customer.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(17)
                .MinimumLength(2)
                .WithMessage("O nome é obrigatório.");

            RuleFor(customer => customer.Salario)
                .NotNull()
                .NotEmpty()
                .WithMessage("O salario é obrigatório.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("O salario não pode ser menor que 0.");


            RuleFor(p => p).Must(BeValid);
        }

        private bool BeValid(FuncionarioInputModel funcionarioInputModel)
        {
            if (funcionarioInputModel.Nome.Equals("string") ||
               funcionarioInputModel.Salario.Equals("string"))
                return false;


            return true;
        }
    }
}
