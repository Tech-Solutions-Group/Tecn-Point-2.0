using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos
{
    public class Chamado
    {
        public long idChamado;

        public string descricao;

        public string titulo;

        public PrioridadeChamado prioridade;

        public StatusChamado status;

        public Usuario cliente;

        public Usuario funcionario;

        public Jornada jornada;

        public Modulo modulo;

        public List<Conversa> conversas;
    }
}
