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
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace TecnPoint.Services
{
    public class ChamadoService
    {
        private readonly HttpClient _httpClient;

        public ChamadoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ChamadoDTO> AbrirChamado(AberturaChamadoDTO aberturaChamadoDTO)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/chamados/abrir-chamado");

            AberturaChamadoDTO chamadoBody = new AberturaChamadoDTO()
            {
                titulo = aberturaChamadoDTO.titulo,
                descricao = aberturaChamadoDTO.descricao,
                prioridade = aberturaChamadoDTO.prioridade,
                idCliente = aberturaChamadoDTO.idCliente,
                idModulo = aberturaChamadoDTO.idModulo,
                idJornada = aberturaChamadoDTO.idJornada
            };

            var jsonBody = JsonSerializer.Serialize(chamadoBody, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            });

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };

                ChamadoDTO chamadoAberto = JsonSerializer.Deserialize<ChamadoDTO>(jsonResposta, options);
                return chamadoAberto;
            }

            var erroAbrirChamado = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroAbrirChamado.mensagem);
        }

        public async Task<List<ChamadoDTO>> BuscarChamados(long idUsuarioLogado, TipoUsuario tipoUsuario)
        {
            var request = new HttpRequestMessage();

            if (tipoUsuario == TipoUsuario.CLIENTE) 
            { 
                request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8080/chamados/chamados-cliente/{idUsuarioLogado}"); 
            }
            else 
            { 
                request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8080/chamados/exibir-todos-chamados"); 
            }

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

            var erroBuscarChamados = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroBuscarChamados.mensagem);
        }

        public async Task<List<ListagemFuncionariosDTO>> CarregaNomeFuncionarios()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/usuarios/listar-funcionarios");

            var response = await _httpClient.SendAsync(request);

            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                List<ListagemFuncionariosDTO> listaFuncionarios = JsonSerializer.Deserialize<List<ListagemFuncionariosDTO>>(jsonResposta);
                return listaFuncionarios;
            }

            var erroCarregarFuncionarios = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroCarregarFuncionarios.mensagem);
        }

        public async Task<ChamadoDTO> AtualizaChamado(AtualizaChamadoDTO atualizaChamadoDTO)
        {
            AtualizaChamadoDTO conteudoBody = new AtualizaChamadoDTO()
            {
                prioridade = atualizaChamadoDTO.prioridade,
                status = atualizaChamadoDTO.status,
                idUsuario = atualizaChamadoDTO.idUsuario,
                idModulo = atualizaChamadoDTO.idModulo,
                idJornada = atualizaChamadoDTO.idJornada
            };

            var jsonBody = JsonSerializer.Serialize(conteudoBody, new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            var request = new HttpRequestMessage(HttpMethod.Patch, $"http://localhost:8080/chamados/{atualizaChamadoDTO.idChamado}");
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };

                ChamadoDTO chamadoAtualizado = JsonSerializer.Deserialize<ChamadoDTO>(jsonResposta, options);
                return chamadoAtualizado;
            }

            var erroAtualizarChamado = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroAtualizarChamado.mensagem);
        }

        public async Task<ChamadoDTO> BuscaChamadoPorId(long idChamado)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8080/chamados/{idChamado}");

            var response = await _httpClient.SendAsync(request);

            var jsonResposta = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter() }
                };

                ChamadoDTO chamadoAtualizado = JsonSerializer.Deserialize<ChamadoDTO>(jsonResposta, options);
                return chamadoAtualizado;
            }

            var erroCarregarChamado = JsonSerializer.Deserialize<MensagemErro>(jsonResposta);
            throw new Exception(erroCarregarChamado.mensagem);
        }
    }
}
