using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn.MENSAGEM
{
    /// <summary>Operação realizada com sucesso</summary>
    public class OperacaoRealizadaMensagem : Mensagem
    {
        /// <summary>Operação realizada com sucesso</summary>
        public OperacaoRealizadaMensagem()
            : base("Operação realizada com sucesso")
        {
        }

        /// <summary>{0} realizada com sucesso</summary>
        /// <param name="operacao"></param>
        public OperacaoRealizadaMensagem(string operacao)
            : base(string.Format("{0} realizada com sucesso", (object)operacao))
        {
        }
    }
}
