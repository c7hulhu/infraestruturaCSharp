using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace InfraKAIQUEv1
{
    /// <summary> Classe de infraestrutura </summary>
    public abstract class Aplicacao
    {
        protected internal Infra infra;

        /// <summary>Construtora da classe</summary>
        public Aplicacao()
        {

        }
        
        /// <summary>Console do MMC disponível para a aplicação</summary>        
        protected internal Infra Infra { get { return this.infra; } }
    }

    /// <summary> Campo que não aceita conteúdo nulo. </summary>
    /// <remarks>Esta estrutura é comumente utilizada para tipar atributos e propriedades que representam 
    /// campos chave e campos not-null da base de dados, nas classes que funcionam como TOs.</remarks>
    public struct CampoObrigatorio<T>
    {
        public object conteudo;
        public bool foiSetado;
        
        public object Conteudo { get { return this.conteudo;} }
        public bool FoiSetado { get { return this.foiSetado;} }

        /// <summary>Construtor da Classe</summary>
        /// <param name="conteudo"></param>
        /// <remarks>Este construtor garante que um Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T> não possui null 
        /// no Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true,
        /// mesmo que T seja um tipo de referência e não de valor.</remarks>        
        public CampoObrigatorio(T conteudo)
        {
            try 
            {	  

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary></summary>
        /// <param name="other"></param>
        /// <returns>true se other for igual ao conteúdo do Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>, senão, false. A seguinte tabela 
        /// descreve como é definida a igualdade para os valores comparados: Valor de retornoDescrição trueSe Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado 
        /// for true e other for igual à Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e other for null.  
        /// false Se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true e other for diferente de Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. 
        /// Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e other não for null.</returns>
        public bool Equals(T other)
        {
            return true;
        }
        
        /// <summary> </summary>
        /// <param name="obj"></param>
        /// <returns> true se obj for igual ao conteúdo do Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>, senão, false. A seguinte tabela descreve como é definida a igualdade 
        /// para os valores comparados: Valor de retornoDescrição trueSe Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true e obj for igual à Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. 
        /// Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e obj for null.  falseSe Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true e obj for diferente 
        /// de Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e obj não for null. </returns>
        public override bool Equals(object obj)
        {
            return true;
        }

        /// <summary></summary>
        /// <returns>O código hash do Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true, senão, zero.</returns>
        public override int GetHashCode()
        {    
            return 1;
        }
        
        /// <summary> </summary>
        /// <param name="retornoPadrao"></param>
        /// <returns></returns>
        public T LerConteudoOuPadrao(T retornoPadrao)
        {
            return retornoPadrao;
        }
        
        /// <summary> </summary>
        /// <param name="retornoPadrao"></param>
        /// <returns></returns>
        public T LerConteudoOuPadrao()
        {
            object value = true;
            return (T) Convert.ChangeType(value, typeof(T));
        }

        public override string ToString()
        {
            return "sad";
        }

        public static implicit operator T(InfraKAIQUEv1.CampoObrigatorio<T> operando)
        {
            object value = true;
            return (T) Convert.ChangeType(value, typeof(T));
        }

        public static implicit operator InfraKAIQUEv1.CampoObrigatorio<T>(T operando)
        {
            return operando;
        }

        /// <summary>Compara a diferença de dois objetos Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.</summary>
        /// <param name="operando1">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <param name="operando2">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <returns>TRUE or FALSE</returns>
        public static bool operator !=(InfraKAIQUEv1.CampoObrigatorio<T> operando1, InfraKAIQUEv1.CampoObrigatorio<T> operando2)
        {
            return true;
        }
        
        /// <summary>Compara a igualdade de dois objetos InfraKAIQUEv1.CampoObrigatorio<T>.</summary>
        /// <param name="operando1">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <param name="operando2">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <returns>TRUE or FALSE</returns>
        public static bool operator ==(InfraKAIQUEv1.CampoObrigatorio<T> operando1, InfraKAIQUEv1.CampoObrigatorio<T> operando2)
        {
            return true;
        }
    }
    
    /// <summary> Campo que aceita conteúdo nulo. </summary>
    /// <remarks>Esta estrutura é comumente utilizada para tipar atributos e propriedades que representam 
    /// campos anuláveis da base de dados, nas classes que funcionam como TOs.</remarks>
    public struct CampoOpcional<T>
    {
        public object conteudo;
        public bool foiSetado;
        public bool temConteudo;

        
        public object Conteudo { get { return this.conteudo;} }
        public bool FoiSetado { get { return this.foiSetado;} }
        public bool TemConteudo { get { return this.temConteudo;} }
        
        /// <summary>Construtor da Classe</summary>
        /// <param name="conteudo"></param>
        /// <remarks>Este construtor garante que um Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T> não possui null 
        /// no Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true,
        /// mesmo que T seja um tipo de referência e não de valor.</remarks>        
        public CampoOpcional(object conteudo)
        {
            
        }

        /// <summary>Construtor da Classe</summary>
        /// <param name="conteudo"></param>
        /// <remarks>Este construtor garante que um Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T> não possui null 
        /// no Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true,
        /// mesmo que T seja um tipo de referência e não de valor.</remarks>        
        public CampoOpcional(T conteudo)
        {

        }

        /// <summary></summary>
        /// <param name="other"></param>
        /// <returns>true se other for igual ao conteúdo do Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>, senão, false. A seguinte tabela 
        /// descreve como é definida a igualdade para os valores comparados: Valor de retornoDescrição trueSe Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado 
        /// for true e other for igual à Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e other for null.  
        /// false Se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true e other for diferente de Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. 
        /// Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e other não for null.</returns>
        public bool Equals(T other)
        {
            return true;
        }
        
        /// <summary> </summary>
        /// <param name="obj"></param>
        /// <returns> true se obj for igual ao conteúdo do Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>, senão, false. A seguinte tabela descreve como é definida a igualdade 
        /// para os valores comparados: Valor de retornoDescrição trueSe Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true e obj for igual à Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. 
        /// Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e obj for null.  falseSe Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true e obj for diferente 
        /// de Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo. Ou se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for false e obj não for null. </returns>
        public override bool Equals(object obj)
        {
            return true;
        }

        /// <summary></summary>
        /// <returns>O código hash do Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.Conteudo se Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.FoiSetado for true, senão, zero.</returns>
        public override int GetHashCode()
        {    
            return 1;
        }
        
        /// <summary> </summary>
        /// <param name="retornoPadrao"></param>
        /// <returns></returns>
        public T LerConteudoOuPadrao(T retornoPadrao)
        {
            return retornoPadrao;
        }
        
        /// <summary> </summary>
        /// <param name="retornoPadrao"></param>
        /// <returns></returns>
        public T LerConteudoOuPadrao()
        {
            object value = true;
            return (T) Convert.ChangeType(value, typeof(T));
        }

        public override string ToString()
        {
            return "sad";
        }

        public static implicit operator T(InfraKAIQUEv1.CampoOpcional<T> operando)
        {
            object value = true;
            return (T) Convert.ChangeType(value, typeof(T));
        }

        public static implicit operator InfraKAIQUEv1.CampoOpcional<T>(T operando)
        {
            return operando;
        }

        /// <summary>Compara a diferença de dois objetos Bergs.Pwx.Pwxoiexn.CampoObrigatorio<T>.</summary>
        /// <param name="operando1">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <param name="operando2">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <returns>TRUE or FALSE</returns>
        public static bool operator !=(InfraKAIQUEv1.CampoOpcional<T> operando1, InfraKAIQUEv1.CampoOpcional<T> operando2)
        {
            return true;
        }
        
        /// <summary>Compara a igualdade de dois objetos InfraKAIQUEv1.CampoObrigatorio<T>.</summary>
        /// <param name="operando1">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <param name="operando2">Um objeto InfraKAIQUEv1.CampoObrigatorio<T>.</param>
        /// <returns>TRUE or FALSE</returns>
        public static bool operator ==(InfraKAIQUEv1.CampoOpcional<T> operando1, InfraKAIQUEv1.CampoOpcional<T> operando2)
        {
            return true;
        }
    }

    /// <summary> Indica a associação entre um campo da tabela e a propriedade de um TO. </summary>
    /// <remarks>O uso do Bergs.Pwx.Pwxoiexn.CampoTabelaAttribute nas propriedades dos TOs é obrigatório 
    /// caso o sistema utilize a funcionalidade de log de ocorrências no BTR integrado ao MM4 ou componentes
    /// genéricos de regra de negócio e acesso a dados.</remarks>
    public sealed class CampoTabelaAttribute
    {
        /// <summary> </summary>
        /// <param name="nomeCampo"> Nome do campo da tabela correspondente à propriedade marcada com o .CampoTabelaAttribute.</param>
        public CampoTabelaAttribute(string nomeCampo)
        {

        }

    }

    /// <summary> Exceção de múltiplos registros afetados pela execução do comando </summary>
    public class BancoDadosException
    {
        /// <summary>Construtora da classe</summary>
        public BancoDadosException()
        {
        }
    }

    /// <summary> Operação realizada com sucesso </summary>
    public class CampoObrigatorioMensagem
    {
        /// <summary>Campo obrigatório {0} não foi informado</summary>
        /// <param name="campo"></param>
        public CampoObrigatorioMensagem(string campo)
        {
        }
    }

    /// <summary> Exceção para chave estrangeira inexistente </summary>
    public class ChaveEstrangeiraInexistenteException
    {
        /// <summary>Não é possível adicionar ou alterar registros, pois é necessário que eles tenham um registro relacionado na tabela XXXXX.</summary>
        /// <param name="msg"></param>
        public ChaveEstrangeiraInexistenteException(String msg)
        {

        }
    }

    /// <summary> Exceção de múltiplos registros afetados pela execução do comando </summary>
    public class ChaveEstrangeiraReferenciadaException
    {
        /// <summary>O registro não pode ser excluído ou alterado porque existe uma ou mais tabelas que incluem registros relacionados a ele.</summary>
        public ChaveEstrangeiraReferenciadaException(String msg)
        {

        }
    }

    /// <summary>Classe de conversão de tipos</summary>
    /// <typeparam name="T">Tipo da classe utilizado na conversão</typeparam>
    public class ConverteXml<T>
           where T : new()
    {
        /// <summary>Converte um tipo de classe ou estrutura T em String</summary>
        /// <param name="classe">Objeto a ser convertido</param>
        /// <returns></returns>
        public static String T2String(T classe)
        {        
            Type tipo = typeof(T);
            if (tipo.IsValueType //é um tipo de dados
                && !tipo.IsPrimitive //não é um tipo primitivo (mas Decimal também não é primitivo)
                && !tipo.IsEnum //não é um enumerador
                && !tipo.Name.StartsWith("System") //não é da biblioteca System
                )
            {
                //é uma struct
                Int32 tamanho = Marshal.SizeOf(classe);
                IntPtr ponteiro = Marshal.AllocHGlobal(tamanho);
                Marshal.StructureToPtr(classe, ponteiro, true);
                String saida = Marshal.PtrToStringAnsi(ponteiro, tamanho).Replace('\0', ' ');
                Marshal.FreeHGlobal(ponteiro);
                return saida;
            }
            else
            {
                //é uma classe
                XmlSerializer x = new XmlSerializer(tipo);
                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    x.Serialize(sw, classe);
                    return sw.ToString();
                }
            }
        } 

        /// <summary>Converte um tipo string XML em um tipo de classe ou struct</summary>
        /// <param name="xml">XML serializado ou string da área da estrutura</param>
        /// <returns></returns>
        public static T String2T(String xml)
        {
            Type tipo = typeof(T);
            if (tipo.IsValueType //é um tipo de dados
                && !tipo.IsPrimitive //não é um tipo primitivo (mas Decimal também não é primitivo)
                && !tipo.IsEnum //não é um enumerador
                && !tipo.Name.StartsWith("System") //não é da biblioteca System
                )
            {
                //é uma struct
                T tipoStruct = new T();
                Int32 tamanho = Marshal.SizeOf(tipo);
                IntPtr pointer = IntPtr.Zero;
                try
                {
                    pointer = Marshal.StringToHGlobalAnsi(xml.PadRight(tamanho, ' '));
                    tipoStruct = (T)Marshal.PtrToStructure(pointer, tipo);
                }
                finally
                {
                    Marshal.FreeHGlobal(pointer);
                }
                return tipoStruct;
            }
            else
            {
                //é uma classe
                XmlSerializer x = new XmlSerializer(tipo);
                T classe;
                using (System.IO.StringReader sr = new System.IO.StringReader(xml))
                {
                    classe = (T)x.Deserialize(sr);
                    return classe;
                }
            }
        }
        
        /// <summary>Converte um vetor de bytes em uma estrutura</summary>
        /// <param name="vetor">Vetor de bytes</param>
        /// <returns>Struct do tipo T</returns>
        public static T Byte2T(byte[] vetor)
        {
            IntPtr pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
            Marshal.Copy(vetor, 0, pointer, vetor.Length);
            T BookBpb = (T)Marshal.PtrToStructure(pointer, typeof(T));
            Marshal.FreeHGlobal(pointer);
            return BookBpb;
        }

        /// <summary>Converte um vetor de chars em uma estrutura</summary>
        /// <param name="vetor">Vetor de chars</param>
        /// <returns>Struct do tipo T</returns>
        public static T Char2T(char[] vetor)
        {
            IntPtr pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
            Marshal.Copy(vetor, 0, pointer, vetor.Length);
            T Book = (T)Marshal.PtrToStructure(pointer, typeof(T));
            Marshal.FreeHGlobal(pointer);
            return Book;
        }

    }
    
    /// <summary>Indica que uma enum deve ser tratada como se composta de System.Char e não de valores numéricos.</summary>
    /// <remarks>Situações de erro: Se uma enum for numérica e possuir a anotação Bergs.Pwx.Pwxoiexn.CharEnumAttribute, seus 
    /// valores serão indevidamente convertidos para System.Char durante a manipulação pela infra-estrutura.  Se uma enum for 
    /// composta de System.Char e não possuir a anotação Bergs.Pwx.Pwxoiexn.CharEnumAttribute, seus valores serão indevidamente 
    /// convertidos para System.Int32 durante a manipulação pela infra-estrutura.  
    /// Definições de enum incorretas: 
    /// [CharEnum()] public enum TipoPessoa { Fisica, Juridica } 
    /// [CharEnum()] public enum TipoPessoa { Fisica = 0, Juridica = 1 } 
    /// public enum TipoPessoa { Fisica = 'F', Juridica = 'J' } 
    /// Definições de enum corretas: 
    /// public enum TipoPessoa { Fisica, Juridica } 
    /// public enum TipoPessoa { Fisica = 0, Juridica = 1 } 
    /// [CharEnum()] public enum TipoPessoa { Fisica = 'F', Juridica = 'J' }</remarks>
    public sealed class CharEnumAttribute
    {
        /// <summary>Construtor da Classe</summary>
        public CharEnumAttribute()
        {

        }
    }

    /// <summary>Disponibiliza formatações de objetos para System.String: cpf, cnpj, data, datahora, agencia, conta </summary>
    /// <remarks>A seguinte tabela descreve as formatações disponíveis: FormatoDescrição cpfFormato de 
    /// CPF: 999.999.999-99.  cnpjFormato de CNPJ: 99.999.999/9999-99.  datahoraFormato de data ou 
    /// hora: 99/99/9999 99:99:99.999999.  agenciaFormato de agência: 9999 ou 9999.9.  contaFormato de conta: 99.999999.9-9.</remarks>
    public class Formatador
    {
        /// <summary>Formatos: "cpf", "cnpj", "data", "datahora", "conta" e "agencia"</summary>
        /// <param name="argumento"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        public String Format(String format, Object argumento, System.IFormatProvider formatProvider)
        {
            return format;
        }

        /// <summary>Construtora da classe</summary>
        public Formatador()
        {

        }

        public object GetFormat(System.Type formatType)
        {

        }
    }

    /// <summary> Concentrador da infra-estrutura MMC - Meta Modelo C# - ConsoleApplication </summary>
    public sealed class Infra
    {
        public CriarEscopoTransacional()
        {

        }

        public Infra()
        {

        }

        public T InstanciarBD<T>()
        {

        }

        public T InstanciarRN<T>()
        {

        }

        public RetornarFalha()

    }

    /// <summary> Classe de retorno de mensagens </summary>
    public class Mensagem
    {
        private String paraOperador;
        protected String mensagem;

        public String ParaOperador
        {
            get { return this.paraOperador; }
        }

        public Mensagem(System.Exception excecao)
        {

        }

        public Mensagem()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
    
    /// <summary>Classe de informação de mensagem inválida</summary>
    public class MensagemInvalidaException
    {
        public MensagemInvalidaException()
        {

        }
    }

    /// <summary>Exceção de múltiplos registros afetados pela execução do comando</summary>
    public class MultiplosDadosException
    {
        public MultiplosDadosException()
        {

        }
    }
    
    /// <summary>Operação realizada com sucesso</summary>
    public class OperacaoRealizadaMensagem
    {
        public OperacaoRealizadaMensagem()
        {

        }
        
        public OperacaoRealizadaMensagem(string operacao)
        {

        }
    }
    
    /// <summary>Exceção de chave primária duplicada</summary>
    public class RegistroDuplicadoException
    {        
        public RegistroDuplicadoException(string msg)
        {

        }
    }
    
    /// <summary>Mensagem de registro inexistente</summary>
    public class RegistroInexistenteMensagem
    {        
        public RegistroInexistenteMensagem()
        {

        }
    }

    /// <summary> Estrutura de retorno </summary>
    public struct Retorno
    {
        public readonly Mensagem Mensagem;
        public readonly bool OK;
    }

    /// <summary> Estrutura de retorno com controle de conversão </summary>
    /// <typeparam name="T">Tipo de dado a ser retornado</typeparam>
    public struct Retorno<T>
    {
        public readonly T Dados;
        public readonly Mensagem Mensagem;
        public readonly bool OK;
    }

    /// <summary> Exceção de violação de integridade arquitetural </summary>
    public class ViolacaoArquiteturalException
    {
        public ViolacaoArquiteturalException()
        {

        }
    }

    /// <summary> Exceção de violação de integridade arquitetural </summary>
    public class ViolacaoBDException
    {
        public ViolacaoBDException()
        {

        }
    }
}
