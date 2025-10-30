using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TecnPoint.Exceptions;
using TecnPoint.Modelos.DTO;
using TecnPoint.Modelos;

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
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("http://localhost:8080/chamados/abrir-chamado", aberturaChamadoDTO);

            if (response.IsSuccessStatusCode)
            {
                var chamadoAberto = await response.Content.ReadFromJsonAsync<ChamadoDTO>();
                return chamadoAberto;
            }

            var erro = await response.Content.ReadFromJsonAsync<MensagemErro>();
            throw new Exception(erro?.mensagem ?? "Erro ao realizar login");
        }
    }
}
