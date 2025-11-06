using System.Text.Json.Serialization;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos
{
    public class Usuario
    {
        public long idUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public override string ToString()
        {
            return $"Id: {idUsuario} \nNome: {Nome} \nEmail: {Email} \nTipo Usuário: {TipoUsuario}";
        }
    }
}
