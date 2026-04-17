using clinicaDocMais.Models;
using System.Data;

namespace clinicaDocMais.DTOs
{
    public class AgendamentoDTOs
    {
        public PacienteModels? paciente {  get; set; }
        public MedicoModel? medico { get; set; }
        public DateTime dataHoraAendada {  get; set; }

    }
}
