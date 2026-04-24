using clinicaDocMais.Data;
using clinicaDocMais.Models;
using clinicaDocMais.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace clinicaDocMais.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

      
        
        private readonly ClinicaContext _context;
        public MedicoController(ClinicaContext context)
        {
            _context = context;
        }


        [HttpPost("cadastroMedico")]
        public async Task<IActionResult> cadastrarMedico([FromBody] MedicoModel medicoCadastrado)
        {
            try
            {
                _context.Add(medicoCadastrado);
                await _context.SaveChangesAsync();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      
        //editar medico

        [HttpPut("editarMedico/{crm}")]
        public async Task<IActionResult> editarMedico([FromBody] MedicoModel MedicoEditado, string crm)
        {
            try
            {
                _context.medicos.Update(MedicoEditado);
                await _context.SaveChangesAsync();
                return Ok(MedicoEditado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //excluir medico
        [HttpDelete("deletarMedico/{crm}")]
        public async Task<IActionResult> deletarMedico(string crm)
        {

            try
            {
                MedicoModel? MedicoEncontrado = await _context.medicos.FindAsync(crm);

                if (MedicoEncontrado != null)
                {

                    _context.medicos.Remove(MedicoEncontrado);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                else
                {
                    throw new Exception($"medico de CRM: {crm} nao existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscaMedico/{crm}")]
        public async Task<IActionResult> BuscarMedico(string crm)
        {

            try
            {
                MedicoModel? MedicoEncontrado = await _context.medicos.FindAsync(crm);
                return Ok(MedicoEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}



