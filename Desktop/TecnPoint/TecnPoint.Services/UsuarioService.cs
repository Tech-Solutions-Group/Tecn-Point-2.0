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
        private JsonSerializerOptions opcoesJson;

        public UsuarioService()
        {
            _httpClient = new HttpClient();
            opcoesJson = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
        }

        public async Task<UsuarioLogadoDTO> RealizarLogin(LoginUsuarioDTO loginUsuarioDTO)
        {
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
                UsuarioLogadoDTO usuarioLogado = JsonSerializer.Deserialize<UsuarioLogadoDTO>(jsonResposta, opcoesJson);
                return usuarioLogado;
            }

            var erroLogin = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroLogin.mensagem);
        }

        public async Task<UsuarioCadastradoDTO> CadastrarUsuario(CadastroUsuarioDTO cadastroUsuarioDTO)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/usuarios/adicionar");

            StringContent content = new StringContent($@"{{
                                            ""nome"" : ""{cadastroUsuarioDTO.nome}"",
                                            ""email"": ""{cadastroUsuarioDTO.email}"",
                                            ""senha"": ""{cadastroUsuarioDTO.senha}"",
                                            ""tipoUsuario"" : ""{cadastroUsuarioDTO.tipoUsuario}""
                                            }}", null, "application/json");
            request.Content = content;
            var response = await _httpClient.SendAsync(request);

            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                UsuarioCadastradoDTO usuarioCadastrado = JsonSerializer.Deserialize<UsuarioCadastradoDTO>(jsonResposta, opcoesJson);
                return usuarioCadastrado;
            }
            var erroCadastro = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroCadastro.mensagem);
        }

        public async Task<List<ListagemUsuarioDTO>> BuscarUsuarios()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/usuarios");

            var response = await _httpClient.SendAsync(request);

            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                List<ListagemUsuarioDTO> listaUsuarios = JsonSerializer.Deserialize<List<ListagemUsuarioDTO>>(jsonResposta, opcoesJson);
                return listaUsuarios;
            }
            var erroBuscarUsuarios = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroBuscarUsuarios.mensagem);
        }

        public async Task<UsuarioAtualizadoDTO> EditarDadosUsuario(EditarUsuarioDTO editarUsuarioDTO)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"http://localhost:8080/usuarios/{editarUsuarioDTO.idUsuario}");

            var jsonBody = JsonSerializer.Serialize(editarUsuarioDTO, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            var content = new StringContent(jsonBody, null, "application/json");

            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                UsuarioAtualizadoDTO usuarioAtualizado = JsonSerializer.Deserialize<UsuarioAtualizadoDTO>(jsonResposta, opcoesJson);
                return usuarioAtualizado;
            }
            var erroAtualizarUsuario = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroAtualizarUsuario.mensagem);
        }
    }
}
