using clinicaDocMais.Data;
using clinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;



namespace clinicaDocMais.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {


        private readonly ClinicaContext _context;
        public PacienteController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpPost("cadastroPaciente")]
        public async Task<IActionResult> cadastrarPaciente([FromBody] PacienteModels pacienteCadastrado)
        {
            try
            {
                _context.Add(pacienteCadastrado);
                await _context.SaveChangesAsync();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("buscaPaciente/{cpf}")]
        public async Task<IActionResult> BuscarPaciente(string cpf)
        {

            try
            {
                PacienteModels? pacieteEncontrado = await _context.medicos.FindAsync(cpf);
                return Ok(pacieteEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("editarPaciente/{cpf}")]
        public async Task<IActionResult> editarPaciente([FromBody] PacienteModels pacienteEditado, string cpf)
        {
            try
            {
                _context.medicos.Update(pacienteEditado);
                await _context.SaveChangesAsync();
                return Ok(pacienteEditado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletarPaciente/{cpf}")]
        public async Task<IActionResult> deletarPaciente(string cpf)
        {

            try { 
            PacienteModels? pacieteEncontrado = await _context.medicos.FindAsync(cpf);

            if (pacieteEncontrado != null)
            {

                _context.medicos.Remove(pacieteEncontrado);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                throw new Exception($"paciente de CPF: {cpf} nao existe");
            }
        }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
            
    }
