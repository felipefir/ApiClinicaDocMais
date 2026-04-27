using clinicaDocMais.Data;
using clinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                PacienteModels? pacieteEncontrado = await _context.pacientes.FindAsync(cpf);
                return Ok(pacieteEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("listarpaciente")]
        public async Task<IActionResult>listarpacientes()
        {
            try
            {
                var listapaciente = _context.pacientes.ToListAsync();
                return Ok(listapaciente);

            }catch (Exception ex)
            {
                return BadRequest("erro."+ ex.Message);
            }
        }

        [HttpGet("buscarPaciente/{nome}")]
        public async Task<IActionResult>buscarPaciente(string nome)
        {
            try
            {
                var listaBuscaPaciente = await _context.pacientes.Where(p => p.nome.Contains(nome)).ToListAsync();
                return Ok(listaBuscaPaciente);


            }catch (Exception ex)
            {
                return BadRequest("erro." +ex.Message);
            }
        }


        [HttpPut("editarPaciente/{cpf}")]
        public async Task<IActionResult> editarPaciente([FromBody] PacienteModels pacienteEditado, string cpf)
        {
            try
            {
                _context.pacientes.Update(pacienteEditado);
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
            PacienteModels? pacieteEncontrado = await _context.pacientes.FindAsync(cpf);

            if (pacieteEncontrado != null)
            {

                _context.pacientes.Remove(pacieteEncontrado);
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
