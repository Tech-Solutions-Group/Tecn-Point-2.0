using TecnPoint.Modelos;
using TecnPoint.Modelos.DTO;
using System.Text.Json;
using TecnPoint.Exceptions;
using System.Net.Http.Json;

namespace TecnPoint.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Usuario> RealizarLogin(string email, string senha)
        {
            var loginUsuarioDTO = new LoginUsuarioDTO
            {
                email = email,
                senha = senha
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("http://localhost:8080/usuarios/login", loginUsuarioDTO);

            if (response.IsSuccessStatusCode)
            {
                var usuarioCadastrado = await response.Content.ReadFromJsonAsync<Usuario>();
                return usuarioCadastrado;
            }

            var erro = await response.Content.ReadFromJsonAsync<MensagemErro>();
            throw new Exception(erro?.Mensagem ?? "Erro ao realizar login");
        }
    }
}
