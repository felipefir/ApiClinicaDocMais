namespace clinicaDocMais.Models
{
    public class PacienteModels
    {
        internal string? especialidade;
        internal string cpf;

        public string? nome {  get; set; }
        public string? dataNascimento {  get; set; }
        public string? crm { get; set; }
        public string? endereco { get; set; }
        public string? telefone { get; set; }
        public string? prioridade {  get; set; }
        public string? email { get; set; }


        public PacienteModels(string? cpf,string? nome,string? dataNasciment,  string? prioridade)
        {
            this.crm = cpf;
            this.nome = nome;
            this.dataNascimento = dataNasciment;
            this.prioridade = prioridade;
        }
    }

}
