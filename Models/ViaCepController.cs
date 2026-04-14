using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinicaDocMais.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViaCepController : ControllerBase
    {
     
        [Route("api/[controller]")]
        [ApiController]
        public class ApiViaCepController : ControllerBase
        {
            [HttpGet("{cep}")]
            public async Task<IActionResult> GetAddress(string cep)
            {
                try
                {
                    // Validação simples
                    if (string.IsNullOrEmpty(cep) || cep.Length != 8)
                        return BadRequest("CEP inválido. Use 8 dígitos.");

                    var client = new HttpClient();
                    var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                    if (!response.IsSuccessStatusCode)
                        return StatusCode((int)response.StatusCode);

                    var content = await response.Content.ReadFromJsonAsync<Via>();

                    // Verifica se o CEP não existe
                    if (content.cep == null)
                        return NotFound("CEP não encontrado.");

                    return Ok(content);
                }
                catch (HttpRequestException ex)
                {
                    // Erro de rede (sem internet, DNS, etc.)
                    Console.WriteLine($"Erro de rede: {ex.Message}");
                    return StatusCode(503, "Erro de conexão com o serviço de CEP.");
                }
                catch (TaskCanceledException ex)
                {
                    // Timeout
                    Console.WriteLine($"Timeout: {ex.Message}");
                    return StatusCode(504, "O serviço demorou para responder.");
                }
                catch (Exception ex)
                {
                    // Erro inesperado
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                    return StatusCode(500, "Erro interno no servidor.");
                }
                finally
                {
                    // Sempre executa
                    Console.WriteLine("Tentativa de busca finalizada.");
                }
            }
        }
    }


}

