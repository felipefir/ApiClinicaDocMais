using clinicaDocMais.Models;
using System.Data;

namespace clinicaDocMais.DTOs
{
    public class AgendamentoDTOs
    {
        public string? id {  get; set; }
        public string? cpfPaciente {  get; set; }
        public string? crmMedico { get; set; }
        public DateTime dataHoraAendada {  get; set; }

    }
}
