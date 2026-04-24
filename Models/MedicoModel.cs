using System.ComponentModel.DataAnnotations;

namespace clinicaDocMais.Models
{
    public class MedicoModel
    {        
        public string? nome {  get; set; } 
        [Key]public string? crm { get; set; }
        public string? endereco { get; set; }
        public string? telefone { get; set; }
        public string? email { get; set; }
        public string? especialidade { get; set; }
        
    }
    }

