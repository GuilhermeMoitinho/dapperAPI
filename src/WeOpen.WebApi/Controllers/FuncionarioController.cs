using Microsoft.AspNetCore.Mvc;
using WebOpen.WebApi.Applications.ServiceResponse;
using WeOpen.WebApi.Domain.Model.Interface;
using Microsoft.AspNetCore.Authorization;
using WeOpen.Application.Applications.DTOs.InputModel.FuncionarioInput;
using WeOpen.Application.Applications.Extensions.ExtensionsInputModel.ExtensionFuncionarioInput;
using WeOpen.Application.Applications.Extensions.ExtensionsResponse.ExtensionFuncionarioResponse;
using WeOpen.Application.Applications.Extensions.ExtensionsViewModel.ExtensionFuncionarioView;

namespace WeOpen.WebApi.Controllers
{
    [Route("api/v1/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly IFuncionarioService _FuncionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
                                 => _FuncionarioService = funcionarioService;

       
        [HttpPost]
        public async Task<IActionResult> Add(FuncionarioInputModel funcionarioInputModel)
        {
            if (funcionarioInputModel is null) return BadRequest();

            var func = funcionarioInputModel.TransFormarEmEntity();

            await _FuncionarioService.Add(func);

            var retorno = new Response()
            {
                Mensagem = "Criado com sucesso",
                Dados = func.Id,
                Sucesso = true
            };

            return CreatedAtAction(nameof(PegarFuncionarioPorId), 
                                   new {Id = func.Id}, 
                                   retorno);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateFuncionarios
                (FuncionarioInputModel funcionarioInputModel, 
                 Guid id)
        {
            if(id == Guid.Empty) return NotFound();

            await _FuncionarioService.UpdateFuncionarios(funcionarioInputModel, id);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFuncionario(Guid id)
        {
            if (id == Guid.Empty) return NotFound();

            await _FuncionarioService.DeleteFuncionario(id);    

            return NoContent();
        }

        [Authorize]
        [HttpGet("{skip}/{take}")]
        public async Task<IActionResult> ListFuncionarios(int skip = 0, int take = 25)
        {           
            var ListFuncionarios = await _FuncionarioService.ListFuncionarios(skip, take);

            var ListFuncViewModel = ListFuncionarios.TransFormarEmViewModel();

            var response = ListFuncViewModel.ResponseListFuncionarioViewModel();

            return Ok(response);
        }

        [ActionName("PegarFuncionarioPorId")]
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> PegarFuncionarioPorId(Guid id)
        {
            if (id == Guid.Empty) return NotFound();

            var FuncionadioViewModel = await _FuncionarioService.PegarFuncionarioPorId(id);

            var Response = FuncionadioViewModel.ResponseFuncionarioViewModel();

            return Ok(Response);
        }


    }
}
