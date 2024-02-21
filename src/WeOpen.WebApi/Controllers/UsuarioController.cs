using Microsoft.AspNetCore.Mvc;
using WeOpen.Application.Applications.DTOs.InputModel.UsuarioInput;
using WeOpen.Application.Applications.Interfaces;
using WeOpen.Domain.Model.Entities;

namespace WebOpen.WebApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioService usuarioService)
            => _UsuarioService = usuarioService;
           
        

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioInputModel usuario)
        {
            var user = await _UsuarioService.ObterUsuarioEspecifico(usuario);

            if (user is false) return NotFound();

            return Ok(await _UsuarioService.Login(usuario));          
        }
    }
}
