using TecnPoint.Enums;

namespace TecnPoint.Modelos
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }

        public override string ToString()
        {
            return $"Id: {Id_usuario} \nNome: {Nome} \nEmail: {Email} \nSenha: {Senha} Tipo Usuário: {TipoUsuario}";
        }
    }
}
