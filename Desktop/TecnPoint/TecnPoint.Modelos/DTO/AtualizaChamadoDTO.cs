using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos.DTO
{
    public class AtualizaChamadoDTO
    {
        public long idChamado { get; set; }
        public PrioridadeChamado? prioridade { get; set; }
        public StatusChamado? status { get; set; }
        public long? idUsuario { get; set; }
        public long? idModulo { get; set; }
        public long? idJornada { get; set; }

        public AtualizaChamadoDTO() { }

        public AtualizaChamadoDTO(long idChamado, PrioridadeChamado prioridade, StatusChamado status, long idUsuario, long idModulo, long idJornada)
        {
            this.idChamado = idChamado;
            this.prioridade = prioridade;
            this.status = status;
            this.idUsuario = idUsuario;
            this.idModulo = idModulo;
            this.idJornada = idJornada;
        }
    }
}
