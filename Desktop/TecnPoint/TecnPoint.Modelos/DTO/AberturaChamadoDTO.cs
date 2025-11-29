using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos.DTO
{
    public class AberturaChamadoDTO
    {
        public string titulo { get; set; }
        public string descricao { get; set; }
        public PrioridadeChamado prioridade { get; set; }
        public long idCliente { get; set; }
        public long idModulo { get; set; }
        public long idJornada { get; set; }

        public AberturaChamadoDTO() { }

        public AberturaChamadoDTO(string titulo, string descricao, PrioridadeChamado prioridade, long idCliente, long idModulo, long idJornada)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.prioridade = prioridade;
            this.idCliente = idCliente;
            this.idModulo = idModulo;
            this.idJornada = idJornada;
        }
    }
}
