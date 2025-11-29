using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos
{
    public class Conversa
    {
        private long _idConversa { get; set; }
        private string _mensagem { get; set; }
        private Chamado _chamado { get; set; }
        private Usuario _remetente { get; set; }
        private DateTime _dataHoraEnvio { get; set; }

        public Conversa() { }

        public long IdConversa
        {
            get { return _idConversa; }
            set { _idConversa = value; }
        }

        public string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }

        public Chamado Chamado
        {
            get { return _chamado; }
            set { _chamado = value; }
        }

        public Usuario Remetente
        {
            get { return _remetente; }
            set { _remetente = value; }
        }

        public DateTime DataHoraEnvio
        {
            get { return _dataHoraEnvio; }
            set { _dataHoraEnvio = value; }
        }
    }
}
