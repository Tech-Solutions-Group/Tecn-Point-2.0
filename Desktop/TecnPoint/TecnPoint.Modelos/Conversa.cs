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
        public string mensagem { get; set; }
        public Chamado chamado { get; set; }
        public Usuario remetente { get; set; }
        public DateTime dataHoraEnvio { get; set; }
    }
}
