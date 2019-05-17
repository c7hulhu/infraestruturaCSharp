using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pxcikaiqueexn
{
    public abstract class Aplicacao
    {
        protected internal Infra infra;

        public Aplicacao()
        {

        }
                
        protected internal Infra Infra
        {
            get { return this.infra; }
        }
    }

    public class BancoDadosException(){
        
        public BancoDadosException()
        {
        }
    }

    public class CampoObrigatorioMensagem()
    {
        public CampoObrigatorioMensagem(string campo)
        {
        }
    }

    public class ChaveEstrangeiraInexistenteException()
    {
        public ChaveEstrangeiraInexistenteException(String msg)
        {

        }
    }
    
    public class ChaveEstrangeiraReferenciadaException()
    {
        public ChaveEstrangeiraReferenciadaException(String msg)
        {

        }
    }

    public class ConverteXml<T>()
    {
        public static T Byte2T(Byte[] vetor) where T : new()
        {

        }

        public static T Char2T(char[] vetor)
        {
            return (T);
        }

        public ConverteXml()
        {

        }

        public static T String2T(String[] vetor)
        {
            return (T)Convert.ChangeType(vetor, typeof(T));
        }

        public static String T2String(T classe)
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(classe);
            object propValue = typeConverter.ConvertFromString();
        }
    }

    public class Formatador()
    {
        public String Format(String format, Object argumento, System.IFormatProvider formatProvider)
        {

        }

        public Formatador()
        {

        }

        public object GetFormat(System.Type formatType)
        {

        }
    }

    public sealed class Infra()
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

    public class Mensagem()
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

    public struct Retorno()
    {
        public readonly Mensagem Mensagem;
        public readonly bool OK;
    }

    public struct Retorno<T>()
    {
        public readonly T Dados;
        public readonly Mensagem Mensagem;
        public readonly bool OK;
    }

    public class ViolacaoArquiteturalException()
    {
        public ViolacaoArquiteturalException()
        {

        }
    }

    public class ViolacaoBDException()
    {
        public ViolacaoBDException()
        {

        }
    }


}
