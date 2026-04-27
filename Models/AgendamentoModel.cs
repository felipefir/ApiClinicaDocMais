
using System.ComponentModel.DataAnnotations;

namespace clinicaDocMais.Models
    {
        public class AgendamentoModel
        {
            public string? id { get; set; }
            // Dados do paciente
           
            public string? cpfPacinte { get; set; }
        public PacienteModels? paciente { get; set; }
            // Dados do médico
           
            public string? CrmMedico { get; set; }
        public MedicoModel? Medico { get; set; }
          

        

            // Data e hora do atendimento
            public DateTime DataHoraAtendimento { get; set; }

            // Presença do paciente
            public bool PresencaConfirmada { get; set; }
        }
    }


