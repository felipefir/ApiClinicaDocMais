using clinicaDocMais.Models;

namespace clinicaDocMais.Services
{
    public class MedicoService
    {
        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();

        

        //metodos
        public MedicoModel? editarMedico(MedicoModel medicoEditado, string crm)
        {
            foreach (var Medico in listaMedicos)
            {
                if (Medico.crm == crm)
                {
                    Medico.crm = medicoEditado.crm;
                    Medico.nome = medicoEditado.nome;
                    Medico.telefone = medicoEditado.telefone;
                    Medico.email = medicoEditado.email;
                    Medico.Especialidade = medicoEditado.Especialidade;
                    Medico.endereco = medicoEditado.endereco;
                    return Medico;
                }
            }
            return null;
        }
    }
}