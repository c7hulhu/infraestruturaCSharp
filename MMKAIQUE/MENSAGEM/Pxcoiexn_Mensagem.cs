using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn.MENSAGEM
{
    /// <summary>Classe de retorno de mensagens</summary>
    public class Mensagem
    {
        /// <summary>Conteúdo da mensagem</summary>
        protected string mensagem;

        /// <summary>Mensagem retornada para o operador</summary>
        public string ParaOperador
        {
            get
            {
                return this.mensagem;
            }
        }

        /// <summary>Construtor da classe</summary>
        public Mensagem()
        {
            this.mensagem = string.Empty;
        }

        /// <summary>Construtor da classe</summary>
        /// <param name="excecao"></param>
        public Mensagem(Exception excecao)
        {
            this.mensagem = excecao.Message;
        }

        /// <summary>Construtor da classe</summary>
        /// <param name="mensagem"></param>
        internal Mensagem(string mensagem)
        {
            this.mensagem = mensagem;
        }

        /// <summary>Mensagem</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.mensagem;
        }
    }
}
