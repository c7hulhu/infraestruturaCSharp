using Pxcoiexn.MENSAGEM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Estrutura de retorno</summary>
    [DebuggerDisplay("Ok = {Ok}, Mensagem = {Mensagem.ParaOperador},nq}")]
    public struct Retorno
    {
        /// <summary>Indica se o método foi realizado com sucesso</summary>
        public readonly bool Ok;
        /// <summary>Mensagem retornada pelo método</summary>
        public readonly Mensagem Mensagem;

        /// <summary>Construtor da classe</summary>
        /// <param name="Ok"></param>
        /// <param name="mensagem">Mensagem, no caso de existir</param>
        internal Retorno(bool Ok, Mensagem mensagem)
        {
            this.Ok = Ok;
            if (mensagem == null)
                throw new MensagemInvalidaException();
            this.Mensagem = mensagem;
        }
    }
}
