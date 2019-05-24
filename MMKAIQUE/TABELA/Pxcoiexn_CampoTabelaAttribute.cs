using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn
{
    /// <summary>
    /// Classe que representa um campo da tabela, utilizada pela classe Linha
    /// </summary>
    [DebuggerDisplay("Nome = {Nome}, Conteudo = {Conteudo}")]
    public sealed class CampoTabelaAttribute
    {
        /// <summary>Nome do campo na base de dados</summary>
        private readonly string Nome;
        /// <summary>Conteúdo do campo lido da base de dados</summary>
        private readonly object Conteudo;

        /// <summary>Construtora da classe</summary>
        /// <param name="nome">Nome do campo na base de dados</param>
        /// <param name="conteudo">Conteúdo do campo</param>
        public CampoTabelaAttribute(string nome, object conteudo)
        {
          this.Nome = nome;
          if (conteudo == DBNull.Value)
            this.Conteudo = (object) null;
          else
            this.Conteudo = conteudo;
    }
  }
}
