using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Services.Validacoes
{
    public class ValidacaoAberturaChamado
    {
        public bool ValidaTitulo(string titulo)
        {
            return (!string.IsNullOrWhiteSpace(titulo));
        }

        public bool ValidaDescricao(string descricao)
        {
            return (!string.IsNullOrWhiteSpace(descricao));
        }

        public bool ValidaPrioridade(int indiceSelecionado)
        {
            return indiceSelecionado > 0;
        }

        public bool ValidaJornada(int indiceSelecionado)
        {
            return indiceSelecionado > 0;
        }

        public bool ValidaModulo(int indiceSelecionado)
        {
            return indiceSelecionado > 0;
        }
    }
}
