using clinicaDocMais.DTOs;
using clinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinicaDocMais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        public static List<AgendamentoModel> listaDeAgendamento = new List<AgendamentoModel>();
        [HttpPost("agentamentoconsulta")]
        public async Task<IActionResult> AgendarConsulta([FromBody] AgendamentoDTOs dadosAgendamento)
        {
            try
            {

                return Created();

            }
            catch (Exception)
            {
                return BadRequest("erro inesperado:");
            }
        }

       
        }
    }

