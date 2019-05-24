using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Exceção para chave estrangeira inexistente</summary>
    public class ChaveEstrangeiraInexistenteException : Exception
    {
        /// <summary>Não é possível adicionar ou alterar registros, pois é necessário que eles tenham um registro relacionado na tabela XXXXX.</summary>
        public ChaveEstrangeiraInexistenteException(string msg)
            : base(msg)
        {
        }
    }
}
