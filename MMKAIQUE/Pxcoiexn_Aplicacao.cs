using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>Classe de infraestrutura</summary>
    public abstract class Aplicacao
    {
        /// <summary>Console do MMC disponível para a aplicação.</summary>
        private Infra infra;

        /// <summary>Console do MMC disponível para a aplicação.</summary>
        protected internal Infra Infra
        {
            get
            {
                return this.infra;
            }
        }

        /// <summary>Construtora da classe</summary>
        public Aplicacao()
        {
            this.infra = new Infra();
        }
    }
}
