using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos.DTO
{
    public class ChamadoDTO
    {
        public long idChamado { get; set; }
        public string descricao { get; set; }
        public string titulo { get; set; }
        public PrioridadeChamado prioridade { get; set; }
        public StatusChamado status { get; set; }
        public UsuarioDTO cliente { get; set; }
        public UsuarioDTO funcionario { get; set; }
        public Jornada jornada { get; set; }
        public Modulo modulo { get; set; }
    }
}
