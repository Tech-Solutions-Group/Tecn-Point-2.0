using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos.DTO
{
    public class UsuarioLogadoDTO
    {
        public long idUsuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
    }
}
