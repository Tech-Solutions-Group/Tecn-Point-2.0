using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos
{
    public class Jornada
    {
        private long _idJornada;
        private string _jornada;

        public Jornada() { }

        public long IdJornada
        {
            get { return _idJornada; }
            set { _idJornada = value; }
        }

        public string JornadaChamado
        {
            get { return _jornada; }
            set { _jornada = value; }
        }
    }
}
