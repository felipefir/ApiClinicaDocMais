using clinicaDocMais.Models;
using Microsoft.EntityFrameworkCore;

namespace clinicaDocMais.Data
{
    public class ClinicaContext:DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options): base (options)
        {
        }
        public DbSet<PacienteModels>pacientes { get; set; }
        public DbSet<MedicoModel>medicos { get; set; }
        public DbSet<AgendamentoModel>agendamentos { get; set; }
        public DbSet<ChamadaModel>chamadas { get; set; }
    }
}
