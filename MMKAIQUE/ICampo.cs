using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Interface que representa um campo da tabela</summary>
    public interface ICampo
    {
        /// <summary>Indica se o campo teve atribuição</summary>
        bool FoiSetado { get; }

        /// <summary>
        /// Retorna o conteúdo do campo, caso não tenha sido setado, retorna null
        /// </summary>
        /// <returns></returns>
        object Conteudo { get; }
    }
}
