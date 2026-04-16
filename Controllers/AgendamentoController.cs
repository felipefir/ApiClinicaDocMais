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
        public async Task<IActionResult> AgendarConsulta([FromBody] PacienteModels pacienteAgendado, MedicoModel medicoAgendado,
            DateTime dataHoraAgendada)
        {

            try
            {
                AgendamentoModel agendamentoAtual = new AgendamentoModel();
                agendamentoAtual.nomePaciente = pacienteAgendado.nome;
                agendamentoAtual.nomeMedico = medicoAgendado.nome;
                agendamentoAtual.Telefone = pacienteAgendado.telefone;
                agendamentoAtual.Cpf = pacienteAgendado.cpf;
                agendamentoAtual.Crm = medicoAgendado.crm;
                agendamentoAtual.especialidadeMedico = medicoAgendado.especialidade;
                agendamentoAtual.DataHoraAtendimento = dataHoraAgendada;
                listaDeAgendamento.Add(agendamentoAtual);
                return Created();

            }
            catch (Exception)
            {
                return Created();
            }
        }
    }
}
