using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraKAIQUEv1.BD
{
    /// <summary>Executa um comando no banco</summary>
    public class AplicacaoDados
    {
        public AplicacaoDados()
        {

        }

    }

    public sealed class Campo
    {
        /// <summary>Construtora da classe</summary>
        /// <param name="nome">Nome do campo na base de dados</param>
        /// <param name="conteudo">Conteúdo do campo</param>
        public Campo(string nome, object conteudo)
        {

        }

    }

    /// <summary>Campo de um TO.</summary>
    public interface ICampo
    {
        object conteudo;
        bool foiSetado;

        bool FoiSetado { get { return this.foiSetado; } }
        object Conteudo { get { return this.conteudo; } }
    }
    
    /// <summary>Campo de um TO.</summary>
    /// <typeparam name="T">Tipo armazenado pelo campo.</typeparam>
    public interface ICampo<T>
    {
        T LerConteudoOuPadrao()
        {
            return 
        }
    }

    public sealed class Linha
    {
        /// <summary>Construtora da classe que inicializa a coleção de campos da tabela</summary>
        public Linha()
        {

        }
        public readonly System.Collections.Generic.List<Campo> Campos;
    }

    public enum OperadoresUnitarios
    {
        /// <summary>Operador <>.</summary>        
        Diferente = "<>",
        /// <summary>Operador =.</summary>  
        Igual = "=",
        /// <summary>Operador IS NOT NULL.</summary>  
        IsNotNull = "IS NOT NULL",
        /// <summary>Operador IS NULL.</summary>  
        IsNull = "IS NULL.",
        /// <summary>Operador LIKE.</summary>  
        Like = "LIKE",
        /// <summary>Operador >.</summary>  
        Maior = ">",
        /// <summary>Operador >.</summary>  
        MaiorIgual = ">=",
    }

    /// <summary>Operadores lógicos para o comando SQL</summary>
    public enum OperadorLogico
    {
        /// <summary>AND - E lógico para montagem do SQL</summary>        
        And = "AND",
        /// <summary>OR - OU lógico para montagem do SQL</summary>  
        Or = "OR",
        /// <summary>XOR - 'EOU' lógico para montagem do SQL</summary>  
        Xor = "XOR",
    }


}
