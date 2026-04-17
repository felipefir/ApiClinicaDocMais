using clinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;



namespace clinicaDocMais.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaudeController : Controller
    {
        public static List<PacienteModels> listaPaciente = new List<PacienteModels>();

        [HttpGet("retornoCasa")]
        public string casa()
        {
            return "casa";
        }



        [HttpGet("nomePaciente")]
        public string paciente()
        {
            string nome = "Giovanni";
            return "Paciente: " + nome;
        }



        [HttpGet("listaPacientes")]
        public List<string> listaNome()
        {
            List<string> listaPacientes = new List<string>();
            listaPacientes = ["Giovanni", "Carlos", "Pedro"];
            return listaPacientes;
        }



        [HttpGet("pacientes")]
        public List<PacienteModels> listarPaciente()
        {
            return listaPaciente;
        }

        [HttpGet("buscaPaciente/{id}")]
        public PacienteModels? BuscarPaciente(string id)
        {
            foreach (var paciente in listaPaciente)
            {
                if (paciente.crm == id)
                {
                    return paciente;
                }
            }
            return null;
        }
        [HttpPut("editarPaciente/{id}")]
        public string editarPaciente([FromBody] PacienteModels pacienteEditado, string id)
        {
            foreach (var paciente in listaPaciente) {
                if (paciente.crm == id)
                {
                    paciente.crm = pacienteEditado.crm;
                    paciente.nome = pacienteEditado.nome;
                    paciente.telefone = pacienteEditado.telefone;
                    paciente.email = pacienteEditado.email;
                   
                    paciente.dataNascimento = pacienteEditado.dataNascimento;
                    paciente.endereco = pacienteEditado.endereco;
                    return $"paciente{paciente.nome},cpf anterior: {id} editado com sucesso";
                }
            }
            return "paciente nao encontrado.";
        }

        [HttpDelete("deletarPaciente/{id}")]
        public string deletarPaciente(string id)
        {
            foreach (var paciente in listaPaciente)
            {
                if (paciente.cpf == id)
                {
                   listaPaciente.Remove(paciente);
                    return $"paciente com cpf {id} removido com sucesso";
                }
        }
            return "paciente nao encotrado.";
        }
    }
}