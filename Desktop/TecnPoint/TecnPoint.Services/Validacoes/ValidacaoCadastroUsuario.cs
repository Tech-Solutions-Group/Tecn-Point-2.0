using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Services.Validacoes
{
    public class ValidacaoCadastroUsuario
    {
        public bool ValidaNome(string nome)
        {
            return (!string.IsNullOrWhiteSpace(nome));
        }

        public bool ValidaEmail(string email)
        {
            return (!string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains("."));
        }

        public bool ValidaSenha(string senha)
        {
            return (!string.IsNullOrWhiteSpace(senha));
        }

        public bool ValidaConfirmacaoDeSenha(string senha, string confirmaSenha)
        {
            return (senha.Equals(confirmaSenha));
        }

        public bool ValidaTipoUsuario(int indiceSelecionado)
        {
            return indiceSelecionado > 0;
        }
    }
}
