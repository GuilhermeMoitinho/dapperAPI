using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebOpen.WebApi.Applications.ServiceResponse;
using WeOpen.Application.Applications.Auth;
using WeOpen.Application.Applications.DTOs.InputModel.UsuarioInput;
using WeOpen.Application.Applications.Interfaces;
using WeOpen.WebApi.Domain.Model.Entities;
using WeOpen.WebApi.Domain.Model.Interface;
using WeOpen.Application.Applications.Extensions.ExtensionsInputModel.ExtensionUsuarioInput;
using WeOpen.Domain.Model.Interface;

namespace WeOpen.Infrastructure.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioScriptsSQL _sql;
        private readonly string _getconnection;
        private readonly TokenService _tokenService;

        public UsuarioRepository(IConfiguration configuration,
                                 IUsuarioScriptsSQL sql,
                                 TokenService tokenService)
        {
            _configuration = configuration;
            _sql = sql;
            _getconnection =
               _configuration.GetConnectionString("ConexaoPadrao");
            _tokenService = tokenService;
        }

        public async Task<Response> Login(UsuarioInputModel userInputModel)
        {
            var user = await ObterUsuarioEspecifico(userInputModel);

            if (user is false) return null;

            var userEntity = userInputModel.TransFormarUsuarioEmEntity();

            var token = _tokenService.GenerateToken(userEntity);

            var response = new Response()
            {
                Mensagem = "Sucesso!",
                Dados = token,
                Sucesso = true
            };

            return response;

        }

        public async Task<bool> ObterUsuarioEspecifico(UsuarioInputModel userInputModel)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = _sql.ObterUsuarioExistente();

                var UsuarioEntity = await con.QueryFirstOrDefaultAsync<Funcionario>(sql,
                                         new
                                         {
                                             Email = userInputModel.Email,  
                                             Senha = userInputModel.Senha
                                         });

                if (UsuarioEntity is null) return false;


                return true;
            }
        }
    }
}
