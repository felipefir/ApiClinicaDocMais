using System.ComponentModel.DataAnnotations;

namespace clinicaDocMais.Models
{
    public class PacienteModels
    {
        
        

        public string? nome { get; set; }
        public DateOnly? dataNascimento { get; set; }
        [Key]public string? cpf { get; set; }
        
        public string? telefone { get; set; }
        
        public string? email { get; set; }
  
    }

}
