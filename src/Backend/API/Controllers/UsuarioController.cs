using Application.UseCases.Usuario.Cadastrar;
using Communication.Requests;
using Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseUsuarioCadastradoJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Cadastrar(
            [FromServices] ICadastrarUsuarioUseCase useCase,
            [FromBody] RequestCadastrarUsuarioJson request
        )
        {

            var resultado = await useCase.Executar(request);

            return Created(string.Empty, resultado);
        }
    }
}