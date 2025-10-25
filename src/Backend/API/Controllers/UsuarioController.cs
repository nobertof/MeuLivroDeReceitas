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
        public IActionResult Cadastrar([FromBody] RequestCadastrarUsuarioJson request)
        {
            return Created();
        }
    }
}