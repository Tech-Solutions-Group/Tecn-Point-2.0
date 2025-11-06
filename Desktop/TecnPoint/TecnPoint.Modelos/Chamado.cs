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

        public string Descricao;

        public string Titulo;

        public PrioridadeChamado Prioridade;

        public StatusChamado Status;

        public Usuario Cliente;

        public Usuario Funcionario;

        public Jornada Jornada;

        public Modulo Modulo;

        public List<Conversa> Conversas;
    }
}
