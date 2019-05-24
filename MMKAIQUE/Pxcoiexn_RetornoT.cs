using Pxcoiexn.MENSAGEM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Estrutura de retorno com controle de conversão</summary>
    /// <typeparam name="T">Tipo de dado a ser retornado</typeparam>
    [DebuggerDisplay("Ok = {Ok}, Dados = {Dados == null ? String.Empty : Dados.ToString() }, Mensagem = {Mensagem == null ? String.Empty : Mensagem.ParaOperador},nq}")]
    public struct Retorno<T>
    {
        /// <summary>Indica se o método foi realizado com sucesso</summary>
        public readonly bool Ok;
        /// <summary>Dados retornados pelo método chamado</summary>
        public readonly T Dados;
        /// <summary>Mensagem retornada pelo método</summary>
        public readonly Mensagem Mensagem;

        /// <summary>Construtor da classe</summary>
        /// <param name="Ok"></param>
        /// <param name="Dados">Dados para serem retornados</param>
        /// <param name="mensagem">Mensagem, no caso de existir</param>
        internal Retorno(bool Ok, T Dados, Mensagem mensagem)
        {
            this.Ok = Ok;
            this.Dados = Dados;
            if (mensagem == null)
                throw new MensagemInvalidaException();
            this.Mensagem = mensagem;
        }
    }
}
