// Decompiled with JetBrains decompiler
// Type: Bergs.Pxc.Pxcoiexn.BD.Linha
// Assembly: Pxcoiexn, Version=1.0.0.7, Culture=neutral, PublicKeyToken=1e29d715e2d068f3
// MVID: 529D4799-E71B-428F-8EDD-3ED073D4AAD6
// Assembly location: C:\Users\Sosa\Downloads\ZIPS\soft\pxc\bin\Pxcoiexn.dll

using System.Collections.Generic;
using System.Diagnostics;

namespace Bergs.Pxc.Pxcoiexn.BD
{
  /// <summary>Classe que representa um registro no banco de dados</summary>
  [DebuggerDisplay("{Campos != null ? \"Campos.Count = \" + Campos.Count.ToString() : ToString(),nq}")]
  public sealed class Linha
  {
    /// <summary>Coleção de campos de um registro da tabela</summary>
    public readonly List<Campo> Campos;

    /// <summary>
    /// Construtora da classe que inicializa a coleção de campos da tabela
    /// </summary>
    public Linha()
    {
      this.Campos = new List<Campo>();
    }
  }
}
