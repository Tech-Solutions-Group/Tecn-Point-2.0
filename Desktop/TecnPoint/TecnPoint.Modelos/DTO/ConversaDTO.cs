using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos.DTO
{
    public class ConversaDTO
    {
        public long idConversa { get; set; }
        public UsuarioDTO remetente { get; set; }
        public string mensagem { get; set; }
        public DateTime dataHoraEnvio { get; set; }
    }
}
