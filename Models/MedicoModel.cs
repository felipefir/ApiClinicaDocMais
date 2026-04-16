namespace clinicaDocMais.Models
{
    public class MedicoModel
    {
        internal string? especialidade;

        public string? nome {  get; set; } 
        public string? crm { get; set; }
        public string? endereco { get; set; }
        public string? telefone { get; set; }
        public string? email { get; set; }
        public string? Especialidade { get; set; }


        public MedicoModel(string? nome, string? crm, string? endereco, string? telefone, string? email,string? especialidade)
        {
            this.nome = nome;
            this.crm = crm;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;
            this.Especialidade = especialidade;
        }

        
    }
    }

