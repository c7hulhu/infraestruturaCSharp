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
    public class BancoDadosException : Exception
    {
        /// <summary>Construtora da classe</summary>
        public BancoDadosException()
            : base("Banco de dados não foi instanciado. Provavelmente a classe RN tenha sido criada com new ao invés de this.Infra.InstanciarRN<T>().")
        {
        }
    }
}
