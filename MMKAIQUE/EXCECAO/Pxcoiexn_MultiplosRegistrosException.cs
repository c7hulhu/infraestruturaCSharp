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
    public class MultiplosDadosException : Exception
    {
        /// <summary>Construtora da classe</summary>
        public MultiplosDadosException()
            : base("Mais de um registro afetado pelo comando. Utilize o método ExecutarMultiplosDados.")
        {
        }
    }
}
