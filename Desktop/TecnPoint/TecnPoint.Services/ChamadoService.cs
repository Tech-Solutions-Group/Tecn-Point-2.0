using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TecnPoint.Exceptions;
using TecnPoint.Modelos.DTO;
using TecnPoint.Modelos;
using System.Text.Json.Serialization;
using System.Text.Json;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Services
{
    public class ChamadoService
    {
        private readonly HttpClient _httpClient;

        public ChamadoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Chamado> AbrirChamado(AberturaChamadoDTO aberturaChamadoDTO)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/chamados/abrir-chamado");

            var content = new StringContent($@"
                                            {{
                                              ""descricao"": ""{aberturaChamadoDTO.descricao}"",
                                              ""titulo"": ""{aberturaChamadoDTO.titulo}"",
                                              ""prioridade"": ""{aberturaChamadoDTO.prioridade}"",
                                              ""idCliente"": {aberturaChamadoDTO.idCliente},
                                              ""idModulo"": {aberturaChamadoDTO.idModulo},
                                              ""idJornada"": {aberturaChamadoDTO.idJornada}
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

                Chamado chamadoAberto = JsonSerializer.Deserialize<Chamado>(jsonResposta, options);
                return chamadoAberto;
            }

            var erroLogin = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroLogin.mensagem);
        }

        public async Task<List<ChamadoDTO>> BuscarChamadosCliente(long idUsuarioLogado)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8080/chamados/chamados-cliente/{idUsuarioLogado}");

            var response = await _httpClient.SendAsync(request);

            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };

                List<ChamadoDTO> listaChamados = JsonSerializer.Deserialize<List<ChamadoDTO>>(jsonResposta, options);
                return listaChamados;
            }

            var erroLogin = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroLogin.mensagem);
        }
    }
}
