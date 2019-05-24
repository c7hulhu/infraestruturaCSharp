using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn.RN
{
    /// <summary>Classe que controla o escopo transacional de acesso ao banco de dados</summary>
    public sealed class EscopoTransacional : IDisposable
    {
        /// <summary>
        /// Método que será acionado ao final da transação, ou pelo Dispose ou pelo EfetivarTransacao
        /// </summary>
        internal EscopoTransacional.FimTransacao OnFimTransacao = (EscopoTransacional.FimTransacao)null;
        private bool fimTransacao = false;

        /// <summary>Método que encerra o escopo, se não tiver efetivado a transação, é realizado um Roolback na base</summary>
        public void Dispose()
        {
            if (this.fimTransacao)
                return;
            this.fimTransacao = true;
            if (this.OnFimTransacao != null)
                this.OnFimTransacao(false);
        }

        /// <summary>Realiza um commit na base após a criação do EscopoTransacional</summary>
        public void EfetivarTransacao()
        {
            if (this.fimTransacao)
                return;
            this.fimTransacao = true;
            if (this.OnFimTransacao != null)
                this.OnFimTransacao(true);
        }

        internal delegate void FimTransacao(bool Commit);
    }
}
