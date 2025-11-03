using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos.DTO
{
    public class EditarUsuarioDTO
    {
        public long idUsuario { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
    }
}
