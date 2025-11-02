using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos.DTO
{
    public class BuscarMensagemDTO
    {
        public long idChamado { get; set; }
        public long idUltimaConversa { get; set; }
    }
}
