using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Exceção de chave primária duplicada</summary>
    public class RegistroDuplicadoException : Exception
    {
        /// <summary>As alterações solicitadas para a tabela não foram satisfatórias já que criariam valores duplicados no índice, chave primária ou relação. Altere os dados no campo ou campos que contêm os dados duplicados, remova o índice ou redefina o índice para possibilitar entradas duplicadas e tente novamente.</summary>
        public RegistroDuplicadoException(string msg)
            : base(msg)
        {
        }
    }
}
