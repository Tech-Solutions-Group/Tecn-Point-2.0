using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos.DTO
{
    public class UsuarioDTO
    {
        public long id_usuario { get; set; }
        public string nome { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
    }
}
