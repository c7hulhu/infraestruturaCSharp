// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.TOTabela
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;
using System.Xml.Serialization;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Classe que representa uma tabela do banco de dados</summary>
  [XmlType("dados")]
  [XmlRoot("tabela")]
  [Serializable]
  public abstract class TOTabela
  {
    /// <summary>Método que popula os campos da tabela recebendo as informações do registro</summary>
    /// <param name="linha"></param>
    public abstract void PopularRetorno(Linha linha);

    /// <summary>
    /// Retorna um campo da tabela já inicializado, se o mesmo for null, já inicializa, caso contrário já realiza a conversão do tipo
    /// </summary>
    /// <typeparam name="T">Tipo de dado do campo na tabela</typeparam>
    /// <param name="conteudo">Conteúdo do campo</param>
    /// <returns></returns>
    public CampoTabela<T> LeCampoTabela<T>(object conteudo)
    {
      if (conteudo == null || conteudo is DBNull)
        return new CampoTabela<T>((object) null);
      return new CampoTabela<T>(conteudo);
    }
  }
}
