using FluentValidation.AspNetCore;
using WebOpen.WebApi.Configuracoes.AuthConfiguracao;
using WebOpen.WebApi.Configuracoes.InjecoesDeDependencia;
using WebOpen.WebApi.Configuracoes.SwaggerConfigruracao;
using WeOpen.Application.Applications.Validacoes.ValidacaoFuncionario;

namespace WeOpen.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.InjetarDependencias();

            builder.Services.AddAuthanticationJwt();

            builder.Services.AddSwagger();

            builder.Services.AddControllers().AddFluentValidation
                (FV => FV.RegisterValidatorsFromAssemblyContaining<FuncionarioValidacao>()); 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
