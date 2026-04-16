    
        namespace clinicaDocMais.Models
    {
        public class AgendamentoModel
        {
            // Dados do paciente
            public string? nomePaciente { get; set; }
            public string? Cpf { get; set; }
            public string? Telefone { get; set; }

            // Dados do médico
            public string? nomeMedico { get; set; }
            public string? Crm { get; set; }
        public string? especialidadeMedico {  get; set; }

        

            // Data e hora do atendimento
            public DateTime DataHoraAtendimento { get; set; }

            // Presença do paciente
            public bool PresencaConfirmada { get; set; }
        }
    }


