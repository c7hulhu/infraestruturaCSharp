using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxcoiexn.MENSAGEM
{
    /// <summary>Operação realizada com sucesso</summary>
    public class CampoObrigatorioMensagem : Mensagem
    {
        /// <summary>Campo obrigatório {0} não foi informado</summary>
        /// <param name="campo"></param>
        public CampoObrigatorioMensagem(string campo)
            : base(string.Format("Campo obrigatório {0} não foi informado", (object)campo))
        {
        }
    }
}
