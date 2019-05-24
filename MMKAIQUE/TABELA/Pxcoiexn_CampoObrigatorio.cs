using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pxcoiexn
{
    /// <summary> Campo que não aceita conteúdo nulo. </summary>
    /// <typeparam name="T">Tipo de dado do campo</typeparam>
    /// <remarks>Esta estrutura é comumente utilizada para tipar atributos e propriedades que representam 
    /// campos chave e campos not-null da base de dados, nas classes que funcionam como TOs.</remarks>
    [DebuggerDisplay("{FoiSetado == true ? ToString() : \"FoiSetado = \" + FoiSetado,nq}")]
    [Serializable]
    public struct CampoObrigatorio<T>
    {
        private bool foiSetadoDado;
        private object conteudo;
        private T dado;

        /// <summary>Retorna o conteúdo do campo no formato String</summary>
        /// <returns></returns>
        public override string ToString()
        {
          try
          {
            if (this.foiSetadoDado)
              return this.dado.ToString();
            return string.Empty;
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        /// <summary>Retorna o conteúdo do campo, caso não tenha sido setado, retorna null</summary>
        [XmlIgnore]
        public object Conteudo
        {
          get
          {
            if (this.foiSetadoDado)
              return (object) this.dado;
            return (object) null;
          }
          set
          {
            if (value != null)
            {
              this.foiSetadoDado = true;
              this.dado = (T) Convert.ChangeType(value, typeof (T));
            }
            else
            {
              this.conteudo = (object) null;
            }
          }
        }

        /// <summary>
        /// Retorna o conteúdo do campo, caso não tenha sido setado, retorna default(T)
        /// </summary>
        /// <returns></returns>
        public T LerConteudoOuPadrao()
        {
          if (this.foiSetadoDado)
            return this.dado;
          if (this.conteudo != null)
            return (T) this.conteudo;
          return default (T);
        }

        /// <summary>
        /// Retorna o conteúdo do campo, caso não tenha sido setado, retorna default(T)
        /// </summary>
        /// <param name="padrao">Valor padrão de retorno caso seja null</param>
        /// <returns></returns>
        public T LerConteudoOuPadrao(T padrao)
        {
          if (this.foiSetadoDado)
            return this.dado;
          if (this.conteudo != null)
            return (T) this.conteudo;
          return padrao;
        }

        /// <summary>Retorna informação de que o campo foi setado, caso tenha sido atribuído</summary>
        [XmlIgnore]
        public bool FoiSetado
        {
          get
          {
            return this.foiSetadoDado;
          }
        }

        /// <summary>Contrutora que aceita null como parâmetro</summary>
        /// <param name="conteudo"></param>
        public CampoObrigatorio(object conteudo)
        {
          if (conteudo == null)
          {
            this.foiSetadoDado = false;
            this.conteudo = (object) null;
            this.dado = default (T);
          }
          else
          {
            try
            {
              this.foiSetadoDado = true;
              this.conteudo = (object) null;
              this.dado = (T) conteudo;
            }
            catch (Exception ex)
            {
              throw new Exception(string.Format("Tipo de dado não é válido. {0}", (object) ex.Message));
            }
          }
        }

        /// <summary>Construtora para inicialização do campo</summary>
        /// <param name="conteudo"></param>
        public CampoObrigatorio(T conteudo)
        {
          if ((object) conteudo == null)
          {
            this.foiSetadoDado = false;
            this.dado = default (T);
            this.conteudo = (object) null;
          }
          else
          {
            this.foiSetadoDado = true;
            this.dado = conteudo;
            this.conteudo = (object) null;
          }
        }

        /// <summary>Inicializa um conteúdo para o campo</summary>
        /// <param name="operando"></param>
        /// <returns></returns>
        public static implicit operator CampoObrigatorio<T>(T operando)
        {
            return new CampoObrigatorio<T>(operando);
        }

        /// <summary>Retorna o conteúdo já tipado</summary>
        /// <param name="operando">Campo da tabela</param>
        /// <returns>Conteúdo do tipo T</returns>
        public static implicit operator T(CampoObrigatorio<T> operando)
        {
          return operando.LerConteudoOuPadrao();
        }

        /// <summary>Retorna o Schema do XML</summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
          return (XmlSchema) null;
        }

        /// <summary></summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
          XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
          bool isEmptyElement = reader.IsEmptyElement;
          reader.Read();
          if (isEmptyElement)
            return;
          this.Conteudo = !reader.HasAttributes ? xmlSerializer.Deserialize(reader) : (object) reader.GetAttribute(0);
          reader.ReadEndElement();
        }

        /// <summary></summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
          XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
          if (this.foiSetadoDado)
          {
            xmlSerializer.Serialize(writer, (object) this.dado);
          }
          else
          {
            if (this.conteudo != null)
              xmlSerializer.Serialize(writer, (object) (T) this.conteudo);
            else
              xmlSerializer.Serialize(writer, (object) null);
          }
        }

        /// <summary>
        /// Compara a diferença de dois objetos Bergs.Pwx.Pxcoiexn.CampoTabela.
        /// </summary>
        /// <param name="operando1">Um objeto do tipo CampoTabela</param>
        /// <param name="operando2">Um objeto do tipo CampoTabela</param>
        /// <returns>true se os operandos são diferentes, senão, false.</returns>
        public static bool operator !=(CampoObrigatorio<T> operando1, CampoObrigatorio<T> operando2)
        {
          return !(operando1 == operando2);
        }

        /// <summary>
        /// Compara a igualdade de dois objetos Bergs.Pwx.Pxcoiexn.CampoTabela.
        /// </summary>
        /// <param name="operando1">Um objeto do tipo CampoTabela</param>
        /// <param name="operando2">Um objeto do tipo CampoTabela</param>
        /// <returns>true se os operandos são iguais, senão, false.</returns>
        public static bool operator ==(CampoObrigatorio<T> operando1, CampoObrigatorio<T> operando2)
        {
          return operando1.FoiSetado.Equals(operando2.FoiSetado) && operando1.LerConteudoOuPadrao().Equals((object) operando2.LerConteudoOuPadrao());
        }

        /// <summary>Compara se o objeto é igual ao CampoTabela</summary>
        /// <param name="obj">Objeto a ser comparado</param>
        /// <returns>true se o conteúdo dos objetos forem iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() is CampoObrigatorio<T>)
                return (CampoObrigatorio<T>)obj == this;
          if (this.FoiSetado)
            return this.conteudo == obj;
          return false;
        }

        /// <summary>Retorno o HashCode</summary>
        /// <returns>Código hash do Conteudo se TemConteudo for true, senão, zero.</returns>
        public override int GetHashCode()
        {
          if (this.Conteudo == null)
              return 0;
          return this.LerConteudoOuPadrao().GetHashCode();
        }
      }
}
