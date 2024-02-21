using WeOpen.Application.Applications.Auth;
using WeOpen.Application.Applications.Interfaces;
using WeOpen.Application.Applications.Services;
using WeOpen.Domain.Model.Interface;
using WeOpen.Infrastructure.Data.Repository;
using WeOpen.Infrastructure.Data.SQL.FuncionarioSQL;
using WeOpen.Infrastructure.Data.SQL.UsuarioSQL;
using WeOpen.WebApi.Applications.Services;
using WeOpen.WebApi.Data.Repository;
using WeOpen.WebApi.Domain.Model.Interface;

namespace WebOpen.WebApi.Configuracoes.InjecoesDeDependencia
{
    public static class InjecoesDeDependencias
    {
        public static void InjetarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioScriptsSQL, FuncionarioScriptsSQL>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository<FuncionarioService>>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioScriptsSQL, UsuarioScriptsSQL>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<TokenService>();
        }
    }
}
