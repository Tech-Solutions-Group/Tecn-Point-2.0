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
        private long _idChamado;

        private string _descricao;

        private string _titulo;

        private PrioridadeChamado _prioridade;

        private StatusChamado _status;

        private Usuario _cliente;

        private Usuario _funcionario;

        private Jornada _jornada;

        private Modulo _modulo;

        private List<Conversa> _conversas;

        public Chamado() { }

        public long IdChamado
        {
            get { return _idChamado;}
            set { _idChamado = value;}
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public string Titulo
        {
            get { return _titulo;} 
            set { _titulo = value; }
        }

        public PrioridadeChamado Prioridade
        {
            get { return _prioridade; }
            set { _prioridade = value; }
        }

        public StatusChamado Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public Usuario Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public Usuario Funcionario
        {
            get { return _funcionario; }
            set { _funcionario = value; }
        }

        public Jornada Jornada
        {
            get { return _jornada; }
            set { _jornada = value; }
        }

        public Modulo Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }

        public List<Conversa> Conversas
        {
            get { return _conversas; }
            set { _conversas = value; }
        } 
    }
}
