// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.CampoTabela`1
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Estrutura que representa um campo da tabela</summary>
  /// <typeparam name="T">Tipo de dado do campo</typeparam>
  [DebuggerDisplay("{FoiSetado == true ? ToString() : \"FoiSetado = \" + FoiSetado,nq}")]
  [Serializable]
  public struct CampoTabela<T> : ICampo, IXmlSerializable
  {
    private bool foiSetadoDado;
    private bool foiSetadoConteudo;
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
        if (this.foiSetadoConteudo)
          return this.conteudo.ToString();
        return string.Empty;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Retorna true se possuir conteúdo diferente de null (caso não tenha sido setado, retorna false)
    /// </summary>
    [XmlIgnore]
    public bool TemConteudo
    {
      get
      {
        return this.foiSetadoDado || this.foiSetadoConteudo && this.conteudo != null;
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
        if (this.foiSetadoConteudo)
          return this.conteudo;
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
          this.foiSetadoConteudo = true;
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
      if (this.foiSetadoConteudo && this.conteudo != null)
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
      if (this.foiSetadoConteudo && this.conteudo != null)
        return (T) this.conteudo;
      return padrao;
    }

    /// <summary>Retorna informação de que o campo foi setado, caso tenha sido atribuído</summary>
    [XmlIgnore]
    public bool FoiSetado
    {
      get
      {
        return this.foiSetadoDado || this.foiSetadoConteudo;
      }
    }

    /// <summary>Contrutora que aceita null como parâmetro</summary>
    /// <param name="conteudo"></param>
    public CampoTabela(object conteudo)
    {
      if (conteudo == null)
      {
        this.foiSetadoConteudo = true;
        this.foiSetadoDado = false;
        this.conteudo = (object) null;
        this.dado = default (T);
      }
      else
      {
        try
        {
          this.foiSetadoDado = true;
          this.foiSetadoConteudo = false;
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
    public CampoTabela(T conteudo)
    {
      if ((object) conteudo == null)
      {
        this.foiSetadoDado = false;
        this.dado = default (T);
        this.foiSetadoConteudo = true;
        this.conteudo = (object) null;
      }
      else
      {
        this.foiSetadoDado = true;
        this.dado = conteudo;
        this.foiSetadoConteudo = false;
        this.conteudo = (object) null;
      }
    }

    /// <summary>Inicializa um conteúdo para o campo</summary>
    /// <param name="operando"></param>
    /// <returns></returns>
    public static implicit operator CampoTabela<T>(T operando)
    {
      return new CampoTabela<T>(operando);
    }

    /// <summary>Retorna o conteúdo já tipado</summary>
    /// <param name="operando">Campo da tabela</param>
    /// <returns>Conteúdo do tipo T</returns>
    public static implicit operator T(CampoTabela<T> operando)
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
        if (!this.foiSetadoConteudo)
          return;
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
    public static bool operator !=(CampoTabela<T> operando1, CampoTabela<T> operando2)
    {
      return !(operando1 == operando2);
    }

    /// <summary>
    /// Compara a igualdade de dois objetos Bergs.Pwx.Pxcoiexn.CampoTabela.
    /// </summary>
    /// <param name="operando1">Um objeto do tipo CampoTabela</param>
    /// <param name="operando2">Um objeto do tipo CampoTabela</param>
    /// <returns>true se os operandos são iguais, senão, false.</returns>
    public static bool operator ==(CampoTabela<T> operando1, CampoTabela<T> operando2)
    {
      return operando1.FoiSetado.Equals(operando2.FoiSetado) && operando1.TemConteudo.Equals(operando2.TemConteudo) && operando1.LerConteudoOuPadrao().Equals((object) operando2.LerConteudoOuPadrao());
    }

    /// <summary>Compara se o objeto é igual ao CampoTabela</summary>
    /// <param name="obj">Objeto a ser comparado</param>
    /// <returns>true se o conteúdo dos objetos forem iguais</returns>
    public override bool Equals(object obj)
    {
      if (obj.GetType() is CampoTabela<T>)
        return (CampoTabela<T>) obj == this;
      if (this.FoiSetado)
        return this.conteudo == obj;
      return false;
    }

    /// <summary>Retorno o HashCode</summary>
    /// <returns>Código hash do Conteudo se TemConteudo for true, senão, zero.</returns>
    public override int GetHashCode()
    {
      if (this.TemConteudo)
        return this.LerConteudoOuPadrao().GetHashCode();
      return 0;
    }
  }
}
