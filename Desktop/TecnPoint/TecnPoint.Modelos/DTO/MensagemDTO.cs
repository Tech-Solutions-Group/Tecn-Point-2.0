using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos.DTO
{
    public class MensagemDTO
    {
        public long idChamado { get; set; }
        public long idRemetente { get; set; }
        public string mensagem { get; set; }
    }
}
