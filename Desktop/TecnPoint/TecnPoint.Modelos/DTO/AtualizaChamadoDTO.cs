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
        public long id_chamado { get; set; }
        public PrioridadeChamado? prioridade { get; set; }
        public StatusChamado? status { get; set; }
        public long? id_usuario { get; set; }
        public long? idModulo { get; set; }
        public long? idJornada { get; set; }

        public AtualizaChamadoDTO() { }

        public AtualizaChamadoDTO(long id_chamado, PrioridadeChamado prioridade, StatusChamado status, long id_usuario, long idModulo, long idJornada)
        {
            this.id_chamado = id_chamado;
            this.prioridade = prioridade;
            this.status = status;
            this.id_usuario = id_usuario;
            this.idModulo = idModulo;
            this.idJornada = idJornada;
        }
    }
}
