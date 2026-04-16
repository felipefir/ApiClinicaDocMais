namespace clinicaDocMais.Models
{
    public class ChamadaModel
    {
        // Nome do paciente
        public string? PacienteNome { get; set; }

        // Ordem na fila de chamada
        public List<ChamadaModel> Chamadas { get; set; } = new List<ChamadaModel>();
        public int OrdemChamada { get; set; }

        // Sala para onde o paciente deve ir
        public string? SalaMedico { get; set; }

        // Horário em que foi chamado
        public DateTime HoraChamada { get; set; }

        // Status da chamada (Aguardando, Chamado, Atendido)
        public string? Status { get; set; }
    }
}