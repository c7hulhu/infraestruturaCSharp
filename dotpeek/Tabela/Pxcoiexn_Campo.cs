// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.Campo
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System;
using System.Diagnostics;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>
  /// Classe que representa um campo da tabela, utilizada pela classe Linha
  /// </summary>
  [DebuggerDisplay("Nome = {Nome}, Conteudo = {Conteudo}")]
  public sealed class Campo
  {
    /// <summary>Nome do campo na base de dados</summary>
    public readonly string Nome;
    /// <summary>Conteúdo do campo lido da base de dados</summary>
    public readonly object Conteudo;

    /// <summary>Construtora da classe</summary>
    /// <param name="nome">Nome do campo na base de dados</param>
    /// <param name="conteudo">Conteúdo do campo</param>
    public Campo(string nome, object conteudo)
    {
      this.Nome = nome;
      if (conteudo == DBNull.Value)
        this.Conteudo = (object) null;
      else
        this.Conteudo = conteudo;
    }
  }
}
