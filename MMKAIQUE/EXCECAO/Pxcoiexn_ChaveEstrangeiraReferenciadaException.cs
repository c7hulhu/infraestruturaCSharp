using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>
    /// Exceção de múltiplos registros afetados pela execução do comando
    /// </summary>
    public class ChaveEstrangeiraReferenciadaException : Exception
    {
        /// <summary>O registro não pode ser excluído ou alterado porque existe uma ou mais tabelas que incluem registros relacionados a ele.</summary>
        public ChaveEstrangeiraReferenciadaException(string msg)
            : base(msg)
        {
        }
    }
}
