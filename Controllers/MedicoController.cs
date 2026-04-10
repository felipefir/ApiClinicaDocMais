using clinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace clinicaDocMais.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();


        [HttpPost("cadastroMedico")]
        public string cadastrarMedico([FromBody] MedicoModel medico)
        {

            listaMedicos.Add(medico);
            return $"Dr. {medico.nome} cadastrodo com sucesso";
        }
        //listar os medicos
        [HttpGet("listaMedico")]
        public List<MedicoModel> listarMedicos()

        {
            return listaMedicos;
        }
        //editar medico

        [HttpPut("editarMedico/{id}")]
        public string editarMedico([FromBody] PacienteModels medicoEditado, string id)
        {
            foreach (var Medico in listaMedicos)
            {
                if (Medico.crm == id)
                {
                    Medico.crm = medicoEditado.crm;
                    Medico.nome = medicoEditado.nome;
                    Medico.telefone = medicoEditado.telefone;
                    Medico.email = medicoEditado.email;
                    Medico.Especialidade = medicoEditado.especialidade;

                    Medico.endereco = medicoEditado.endereco;
                    return $"medico{Medico.nome},crm anterior: {id} editado com sucesso";
                }
            }
            return "medico nao encontrado.";
        }
        //excluir medico
        [HttpDelete("deletarMedico/{id}")]
        public string deletarMedico(string id)
        {
            foreach (var medico in listaMedicos)
            {
                if (medico.crm == id)
                {
                    listaMedicos.Remove(medico);
                    return $"medico com crm {id} removido com sucesso";
                }
            }
            return "medico nao encotrado.";
        }
        
        [HttpGet("buscaMedico/{id}")]
        public MedicoModel? BuscarMedico(string id)
        {
            foreach (var medico in listaMedicos)
            {
                if (medico.crm != id)
                {
                    continue;
                }
                return medico;
            }
            return null;
        }
    }
}



