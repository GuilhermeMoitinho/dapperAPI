using WeOpen.WebApi.Domain.Model.Interface;

namespace WeOpen.Infrastructure.Data.SQL.FuncionarioSQL
{
    public class FuncionarioScriptsSQL : IFuncionarioScriptsSQL
    {
        public string InsertInto()
        {
            return "INSERT INTO Funcionario (Id, Nome, Salario) VALUES (@Id, @Nome, @Salario);";
        }

        public string SelectAllFuncionarios()
        {
            return "SELECT * FROM Funcionario ORDER BY Id OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
        }

        public string SelectIdFuncionario()
        {
            return "SELECT * FROM Funcionario WHERE Id = @Id";
        }

        public string UpdateFuncionario()
        {
            return "UPDATE Funcionario SET Nome = @Nome, Salario = @Salario WHERE Id = @Id";
        }

        public string DeleteFuncionario()
        {
            return "DELETE FROM Funcionario WHERE Id = @Id";
        }

    }
}
