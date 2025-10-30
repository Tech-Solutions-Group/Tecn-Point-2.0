using TecnPoint.Modelos;
using TecnPoint.Modelos.DTO;
using System.Text.Json;
using TecnPoint.Exceptions;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace TecnPoint.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Usuario> RealizarLogin(LoginUsuarioDTO loginUsuarioDTO)
        {
            var jsonLogin = JsonSerializer.Serialize(loginUsuarioDTO);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/usuarios/login");

            StringContent content = new StringContent($@"{{
                                            ""email"": ""{loginUsuarioDTO.email}"",
                                            ""senha"": ""{loginUsuarioDTO.senha}""
                                            }}", null, "application/json");

            request.Content = content;
            var response = await _httpClient.SendAsync(request);

            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                }; 

                Usuario usuarioLogado = JsonSerializer.Deserialize<Usuario>(jsonResposta, options);
                return usuarioLogado;
            }

            var erroLogin = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroLogin.mensagem);
        }
    }
}
