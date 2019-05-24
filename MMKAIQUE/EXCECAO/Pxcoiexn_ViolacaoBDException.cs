using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Exceção de violação de integridade arquitetural</summary>
    public class ViolacaoBDException : Exception
    {
        /// <summary>Construtora da classe</summary>
        public ViolacaoBDException()
            : base("Não é permitido instanciar uma camada de BD ou RN a partir da camada de BD.")
        {
        }
    }
}
