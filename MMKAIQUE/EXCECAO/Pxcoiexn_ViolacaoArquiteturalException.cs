using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Exceção de violação de integridade arquitetural</summary>
    public class ViolacaoArquiteturalException : Exception
    {
        /// <summary>Construtora da classe</summary>
        public ViolacaoArquiteturalException()
            : base("Não é permitido instanciar uma camada de BD a partir de uma RN de identificadores diferentes.")
        {
        }
    }
}
