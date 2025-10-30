using System.Text.Json.Serialization;
using TecnPoint.Modelos.Enum;

namespace TecnPoint.Modelos
{
    public class Usuario
    {
        public long id_usuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public TipoUsuario tipoUsuario { get; set; }

        public override string ToString()
        {
            return $"Id: {id_usuario} \nNome: {nome} \nEmail: {email} \nSenha: {senha} Tipo Usuário: {tipoUsuario}";
        }
    }
}
