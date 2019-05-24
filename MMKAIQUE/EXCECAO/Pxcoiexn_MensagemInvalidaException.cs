using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Classe de informação de mensagem inválida</summary>
    public class MensagemInvalidaException : Exception
    {
        /// <summary>Construtora da classe</summary>
        public MensagemInvalidaException()
            : base("Mensagem inválida ou nula")
        {
        }
    }
}
