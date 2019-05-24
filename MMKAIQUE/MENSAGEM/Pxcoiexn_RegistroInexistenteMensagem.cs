using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn.MENSAGEM
{
    /// <summary>Mensagem de registro inexistente</summary>
    public class RegistroInexistenteMensagem : Mensagem
    {
        /// <summary>Construtora da classe</summary>
        public RegistroInexistenteMensagem()
            : base("Registro inexistente")
        {
        }
    }
}
