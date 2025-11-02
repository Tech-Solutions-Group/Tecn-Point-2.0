using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TecnPoint.Exceptions;
using TecnPoint.Modelos.DTO;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace TecnPoint.Services
{
    public class ConversaService
    {
        private readonly HttpClient _httpClient;

        public ConversaService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ConversaDTO>> BuscarConversa(BuscarMensagemDTO buscarMensagemDTO)
        {
            BuscarMensagemDTO mensagem = new BuscarMensagemDTO
            {
                idChamado = buscarMensagemDTO.idChamado,
                idUltimaConversa = buscarMensagemDTO.idUltimaConversa
            };
            var jsonBody = JsonSerializer.Serialize(mensagem);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/conversas/buscar-mensagens");
            var content = new StringContent(jsonBody, null, "application/json");

            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };

                List<ConversaDTO> listaMensagens = JsonSerializer.Deserialize<List<ConversaDTO>>(jsonResposta, options);
                return listaMensagens;
            }

            var erroBuscarMensagens = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroBuscarMensagens.mensagem);
        }

        public async Task<ConversaDTO> EnviarMensagem(MensagemDTO mensagemDTO)
        {
            var jsonBody = JsonSerializer.Serialize(mensagemDTO);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/conversas/enviar-mensagem");

            var content = new StringContent(jsonBody, null, "application/json");

            request.Content = content;

            var response = await _httpClient.SendAsync(request);

            var jsonResposta = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };

                ConversaDTO mensagemEnviada = JsonSerializer.Deserialize<ConversaDTO>(jsonResposta, options);
                return mensagemEnviada;
            }

            var erroEnviarMensagem = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroEnviarMensagem.mensagem);
        }
    }
}
