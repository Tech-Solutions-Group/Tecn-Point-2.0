using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos.DTO
{
    public class LoginUsuarioDTO
    {
        public string email { get; set; }
        public string senha { get; set; }

        public LoginUsuarioDTO(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }
    }
}
