using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos
{
    public class Conversa
    {
        public int IdConversa { get; set; }
        public string Mensagem { get; set; }
        public Chamado Chamado { get; set; }
        public Usuario Remetente { get; set; }
        public DateTime DataHoraEnvio { get; set; }
    }
}
