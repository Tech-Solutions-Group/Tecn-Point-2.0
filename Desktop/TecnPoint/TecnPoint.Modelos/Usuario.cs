using System.Text.Json.Serialization;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos
{
    public class Usuario
    {
        private long _idUsuario { get; set; }
        private string _nome { get; set; }
        private string _email { get; set; }
        private TipoUsuario _tipoUsuario { get; set; }

        public long IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public TipoUsuario TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }
    }
}
