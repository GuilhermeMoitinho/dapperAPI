using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WeOpen.WebApi.Domain.Model.Entities;
using WeOpen.WebApi.Domain.Model.Interface;
using WeOpen.Application.Applications.DTOs.InputModel.FuncionarioInput;
using WeOpen.Application.Applications.Extensions.ExtensionsInputModel.ExtensionFuncionarioInput;
using WeOpen.Application.Applications.DTOs.ViewModel.FuncionarioView;
using WeOpen.Application.Applications.Extensions.ExtensionsViewModel.ExtensionFuncionarioView;

namespace WeOpen.WebApi.Data.Repository
{
    public class FuncionarioRepository<T> : IFuncionarioRepository where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly IFuncionarioScriptsSQL _sql;
        private readonly string _getconnection;

        public FuncionarioRepository(IConfiguration configuration, IFuncionarioScriptsSQL sql)
        {
            _configuration = configuration;
            _sql = sql;
            _getconnection =
                _configuration.GetConnectionString("ConexaoPadrao");
        }

        public async Task Add(Funcionario funcionario)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = _sql.InsertInto();

                await con.ExecuteScalarAsync<Funcionario>
                    (sql, funcionario);
            }
        }

        public async Task<IEnumerable<Funcionario>> ListFuncionarios(int skip, int take)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = _sql.SelectAllFuncionarios();

                var ListaDeFuncionarios =
                    await con.QueryAsync<Funcionario>
                    (sql, new { Skip = skip, Take = take });

                return ListaDeFuncionarios;
            }
        }

        public async Task<FuncionarioViewModel> PegarFuncionarioPorId(Guid id)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = _sql.SelectIdFuncionario();

                var funcionarioEntity = await con.QueryFirstOrDefaultAsync<Funcionario>(sql, new { Id = id });

                var funcionarioViewModel = funcionarioEntity.TransFormaEmViewModel();

                return funcionarioViewModel;
            }
        }

        public async Task UpdateFuncionarios(FuncionarioInputModel funcionarioInputModel, Guid id)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = _sql.UpdateFuncionario();

                var FuncionarioEntity = funcionarioInputModel.TransFormarEmEntity();

                await con.ExecuteAsync(sql, new
                {
                    Nome = FuncionarioEntity.Nome,
                    Salario = FuncionarioEntity.Salario,
                    Id = id
                });
            }
        }

        public async Task DeleteFuncionario(Guid id)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = _sql.DeleteFuncionario();

                await con.ExecuteAsync(sql, new
                {
                    Id = id
                });
            }
        }
    }
}
