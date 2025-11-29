using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnPoint.Modelos
{
    public class Modulo
    {
        private long _idModulo;
        private string _modulo;

        public Modulo() { }

        public long IdModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }

        public string ModuloChamado
        {
            get { return _modulo; }
            set { _modulo = value; }
        }
    }
}
