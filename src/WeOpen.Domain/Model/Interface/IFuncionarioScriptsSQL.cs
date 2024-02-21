using WeOpen.WebApi.Domain.Model.Entities;

namespace WeOpen.WebApi.Domain.Model.Interface
{
    public interface IFuncionarioScriptsSQL
    {
        string InsertInto();

        string SelectAllFuncionarios();

        string SelectIdFuncionario();

        string UpdateFuncionario();

        string DeleteFuncionario();
    }
}
