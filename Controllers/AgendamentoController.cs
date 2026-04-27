using clinicaDocMais.Data;
using clinicaDocMais.DTOs;
using clinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinicaDocMais.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
       
        private ClinicaContext _context;
        public AgendamentoController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpPost("agentamentoconsulta")]
        public async Task<IActionResult> AgendarConsulta([FromBody] AgendamentoDTOs dadosAgendamento)
        {
            try
            {//conversao de dto para o model
                AgendamentoModel agendamento = new AgendamentoModel();

                agendamento.id = dadosAgendamento.id;
                agendamento.DataHoraAtendimento = dadosAgendamento.dataHoraAendada;
                agendamento.CrmMedico = dadosAgendamento.crmMedico;
                agendamento.cpfPacinte = dadosAgendamento.cpfPaciente;

              await  _context.agendamentos.AddAsync(agendamento);

               _context.SaveChanges();

                return Created();

            }
            catch (Exception ex)
            {
                return BadRequest("erro inesperado:" + ex.Message);
            }
        }
        [HttpGet("buscarAgendamentoS")]

        public async Task<IActionResult> BuscarAgendamentos()
        {
            try
            {
              var listaAgendamento = await _context.agendamentos.Include(p => p.paciente).Include(m => m.Medico).ToListAsync();
                return Ok(listaAgendamento);

            }catch(Exception ex)
            {
                return BadRequest("erro."+ex.Message);
            }
        }

       
        }
    }

