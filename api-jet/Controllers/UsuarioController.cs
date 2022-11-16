using api.Data;
using api.Extensions;
using api.Models;
using api.Services;
using api.ViewModels.Result;
using api.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using Microsoft.AspNetCore.Authorization;
using api.ViewModels;
namespace api.Controllers
{

    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpPost("v1/usuarios/login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody] LoginViewModel model,
            [FromServices] DataBaseContext context,
            [FromServices] TokenService tokenService)
        {

            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var usuario = await context
                   .Usuario
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.usuario == model.usuario);

            if (usuario == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválido"));

            if (!PasswordHasher.Verify(usuario.senha, model.senha + Configuration.JwtKey))
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválido"));

            try
            {
                var token = tokenService.GenerateToken(usuario);

                return Ok(new ResultViewModel<dynamic>("Login Efetuado com sucesso!", true,
                    new
                    {
                        accessToken  = token
                    }, new List<string>()));

            }
            catch (Exception)
            {

                throw;
            }
            
        }


        [Authorize]
        [HttpGet("v1/usuarios/nome/{usuario}")]
        public async Task<IActionResult> GetById(
          [FromRoute] string usuario,
          [FromServices] DataBaseContext context)
        {

            try
            {

                //Monta Array de dados
                var data = await context
                    .Usuario
                    .AsNoTracking()
                    .Select(x => new ListUsuarioViewModel
                    {
                        codigo = x.codigo,
                        usuario = x.usuario,
                        senha = x.senha,
                        nome = x.nome

                    })
                    .FirstOrDefaultAsync(x => x.usuario == usuario);

                if (data == null)
                    return NotFound(new ResultViewModel<UsuarioModel>("05X02 - Conteúdo não encontrado"));

                //Retorna dados
                return Ok(new ResultViewModel<dynamic>("Dados Carregados com sucesso!", true,
                    new
                    {
                        data
                    }, new List<string>()));

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<UsuarioModel>("05X02 - Falha interna no servidor"));
            }
        }

    }
}

